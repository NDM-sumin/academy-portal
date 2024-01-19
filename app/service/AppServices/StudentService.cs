using AutoMapper;
using domain;
using domain.shared.AppSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using repository.AppRepositories;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Major;
using service.contract.DTOs.Semester;
using service.contract.DTOs.SlotTimeTableAtWeek;
using service.contract.DTOs.Student;
using service.contract.DTOs.StudentSemester;
using service.contract.DTOs.Subject;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class StudentService : AppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>, IStudentService
    {
        readonly JwtConfiguration _jwtConfiguration;
        readonly IMajorService _majorService;
        readonly ISlotTimeTableAtWeekService slotTimeTableAtWeekService;
        readonly IFeeDetailService feeDetailService;
        readonly ISemesterService semesterService;
        readonly IStudentSemesterService studentSemesterService;
        readonly IAttendanceService attendanceService;
        readonly IStudentSemesterRepository studentSemesterRepository;
        readonly ISubjectRepository subjectService;
        readonly IFeeDetailRepository feeDetailRepository;
        public StudentService(IStudentRepository genericRepository, IStudentSemesterRepository studentSemesterRepository,
            IMajorService majorService,
            ISemesterService semesterService,
            ISubjectRepository subjectRepository, IFeeDetailRepository feeDetailRepository,
            IStudentSemesterService studentSemesterService,
            IAttendanceService attendanceService,
            IMapper mapper,
            IOptions<JwtConfiguration> jwtConfiguration,
            ISlotTimeTableAtWeekService slotTimeTableAtWeekService,
            IFeeDetailService feeDetailService) : base(genericRepository, mapper)
        {
            _majorService = majorService;
            _jwtConfiguration = jwtConfiguration.Value;
            this.slotTimeTableAtWeekService = slotTimeTableAtWeekService;
            this.feeDetailService = feeDetailService;
            this.feeDetailRepository = feeDetailRepository;
            this.semesterService = semesterService;
            this.studentSemesterService = studentSemesterService;
            this.attendanceService = attendanceService;
            this.studentSemesterRepository = studentSemesterRepository;
            this.subjectService = subjectRepository;
        }

        public async Task ImportStudentsFromExcel(IFormFile file)
        {
            List<Student> students = new List<Student>();

            using (var stream = file.OpenReadStream())
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    MajorDTO major = _majorService.GetMajorByCode(worksheet.Cells[row, 7].Value.ToString()).Result;
                    Student student = new Student
                    {
                        Username = worksheet.Cells[row, 1].Value.ToString(),
                        FullName = worksheet.Cells[row, 2].Value.ToString(),
                        Email = worksheet.Cells[row, 3].Value.ToString(),
                        Dob = DateTime.Parse(worksheet.Cells[row, 4].Value.ToString()),
                        Gender = Convert.ToBoolean(worksheet.Cells[row, 5].Value),
                        Phone = worksheet.Cells[row, 6].Value.ToString(),
                        MajorId = major.Id,
                        Password = new HashService("123456", _jwtConfiguration.HashSalt).EncryptedPassword
                    };

                    students.Add(student);

                }
            }
            await base.Repository.AddRange(students);
        }

        public override Task<StudentDTO> Create(CreateStudentDTO entityDto)
        {
            entityDto.Id = Guid.NewGuid();
            entityDto.Password = "123456";
            HashService hashService = new HashService(entityDto.Password, _jwtConfiguration.HashSalt);
            entityDto.Password = hashService.EncryptedPassword;
            return base.Create(entityDto);
        }

        public async Task RegisterSubject(Guid studentId, Guid subjectId)
        {
            CreateFeeDetailDTO feeDetailDTO = new();
            feeDetailDTO.Id = Guid.NewGuid();
            feeDetailDTO.SubjectId = subjectId;
            feeDetailDTO.StudentSemesterId = studentSemesterService.GetCurrentSemester(studentId).Result.Id;
            feeDetailDTO.Amount = (float)(await subjectService.Find(subjectId)).Price;
            feeDetailDTO.DueDate = DateTime.Now.AddDays(20);
            feeDetailService.Create(feeDetailDTO);
        }


        public async Task<List<StudentTimetableDto>> GetTimeTable(Guid studentId)
        {
            List<StudentTimetableDto> result = new();

            var currentSemester = (await studentSemesterService.GetCurrentSemester(studentId)).Semester;
            var fees = await feeDetailService.GetByStudent(studentId, currentSemester.Id);

            var year = DateTime.Now.Year;
            DateTime startOfTerm = new DateTime(year, currentSemester.StartMonth, currentSemester.StartDay);
            if (currentSemester.StartMonth > currentSemester.EndMonth) { year++; }
            DateTime endOfTerm = new DateTime(year, currentSemester.EndMonth, currentSemester.EndDay);

            foreach (var item in fees)
            {
                var room = await attendanceService.GetRoomByFee(item.Id);
                StudentTimetableDto timeTable = new()
                {
                    Class = item.Class,
                    Subject = item.Subject,
                    StartDate = startOfTerm,
                    EndDate = endOfTerm,
                    Room = room
                };
                List<SlotTimeTableAtWeekDTO> list = await slotTimeTableAtWeekService.GetSlotTimeTableAtWeeks(currentSemester, item.Id);
                var unique = list
                             .GroupBy(sc => new { sc.TimetableId, sc.SlotId })
                             .Select(group => group.First())
                             .ToList();
                timeTable.AtWeek.AddRange(Mapper.Map<List<SlotTimeTableAtWeekDTO>, List<AtWeekDto>>(unique));
                result.Add(timeTable);
            }
            return result;
        }

        public List<SubjectDTO> GetFailedSubjects(Guid studentId)
        {
            var data = base.Repository.Entities.Find(studentId)
                        .Scores.GroupBy(s => s.SubjectComponent.Subject).Where(sj => sj.Sum(sc => sc.Value * sc.SubjectComponent.Weight) < 5)
                        .Select(s => s.Key).ToList();
            return Mapper.Map<List<SubjectDTO>>(data);
        }
        public async Task<List<SemesterDTO>> GetSemesterByStudent(Guid studentId)
        {
            var data = studentSemesterRepository.Entities.Include(ss => ss.Semester)
                .Where(ss => ss.StudentId == studentId).Select(ss =>
                ss.Semester).ToList();
            return Mapper.Map<List<SemesterDTO>>(data!);
        }

        public async Task<List<FeeDetailDTO>> GetFeeHistory(Guid studentId, Guid semesterId)
        {
            var result = feeDetailRepository.GetAll().Result.Include(fd => fd.StudentSemester).Include(fd => fd.Subject).Where(fd => fd.StudentSemester.StudentId == studentId && fd.StudentSemester.SemesterId == semesterId).ToList();
            return Mapper.Map<List<FeeDetailDTO>>(result);
        }
    }
}
