using AutoMapper;
using domain;
using domain.shared.AppSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
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
        public StudentService(IStudentRepository genericRepository,
            IMajorService majorService,
            ISemesterService semesterService,
            IMapper mapper,
            IOptions<JwtConfiguration> jwtConfiguration,
            ISlotTimeTableAtWeekService slotTimeTableAtWeekService,
            IFeeDetailService feeDetailService) : base(genericRepository, mapper)
        {
            _majorService = majorService;
            _jwtConfiguration = jwtConfiguration.Value;
            this.slotTimeTableAtWeekService = slotTimeTableAtWeekService;
            this.feeDetailService = feeDetailService;
            this.semesterService = semesterService;
        }

        public async Task ImportStudentsFromExcel(IFormFile file)
        {
            var studentDtos = new List<StudentDTO>();

            using (var stream = file.OpenReadStream())
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    MajorDTO major = await _majorService.GetMajorByCode(worksheet.Cells[row, 7].Value.ToString());
                    var student = new StudentDTO
                    {
                        Username = worksheet.Cells[row, 1].Value.ToString(),
                        FullName = worksheet.Cells[row, 2].Value.ToString(),
                        Email = worksheet.Cells[row, 3].Value.ToString(),
                        Dob = DateTime.Parse(worksheet.Cells[row, 4].Value.ToString()),
                        Gender = Convert.ToBoolean(worksheet.Cells[row, 5].Value),
                        Phone = worksheet.Cells[row, 6].Value.ToString(),
                        MajorId = major.Id,
                        Major = major
                    };
                    student.Id = Guid.NewGuid();
                    student.Password = Guid.NewGuid().ToString();
                    HashService hashService = new(student.Password, _jwtConfiguration.HashSalt);
                    student.Password = hashService.EncryptedPassword;
                    studentDtos.Add(student);
                }
            }
            var students = Mapper.Map<List<Student>>(studentDtos);
            await base.Repository.AddRange(students);
        }
        public async Task<StudentSemesterDto> GetCurrentSemester(Guid studentId)
        {
            StudentSemester? data = (await this.Repository.Entities
                .FirstOrDefaultAsync(s => s.Id == studentId))?
                .StudentSemesters
                .FirstOrDefault(s => s.IsNow == true);
            return Mapper.Map<StudentSemesterDto>(data!);
        }
        public override Task<StudentDTO> Create(CreateStudentDTO entityDto)
        {
            entityDto.Id = Guid.NewGuid();
            entityDto.Password = Guid.NewGuid().ToString();
            HashService hashService = new HashService(entityDto.Password, _jwtConfiguration.HashSalt);
            entityDto.Password = hashService.EncryptedPassword;
            return base.Create(entityDto);
        }

        public async Task RegisterSubject(CreateFeeDetailDTO createFeeDetailDTO)
        {

        }


        public async Task<List<StudentTimetableDto>> GetTimeTable(Guid studentId)
        {
            List<StudentTimetableDto> result = new();

            var currentSemester = (await GetCurrentSemester(studentId)).Semester;
            var fees = await feeDetailService.GetByStudent(studentId, currentSemester.Id);

            var year = currentSemester.CreatedAt.Year;
            DateTime startOfTerm = new DateTime(year, currentSemester.StartMonth, currentSemester.StartDay);
            if (currentSemester.StartMonth > currentSemester.EndMonth) { year++; }
            DateTime endOfTerm = new DateTime(year, currentSemester.EndMonth, currentSemester.EndDay);

            foreach (var item in fees)
            {
                StudentTimetableDto timeTable = new()
                {
                    Subject = item.Subject,
                    StartDate = startOfTerm,
                    EndDate = endOfTerm,
                    Room = item.Attendances.FirstOrDefault().Room
                };
                List<SlotTimeTableAtWeekDTO> list = await slotTimeTableAtWeekService.GetSlotTimeTableAtWeeks(currentSemester);
                timeTable.AtWeek.AddRange(list);
                result.Add(timeTable);
            }
            return result;
        }

        public List<SubjectDTO> GetFailedSubjects(Guid studentId)
        {
            var data = base.Repository.Entities.Find(studentId)
                        .Scores.GroupBy(s => s.SubjectComponent.Subject)
                        .Where(sj => sj.Sum(sc => sc.Value * sc.SubjectComponent.Weight) < 5)
                        .Select(s => s.Key);
            return Mapper.Map<IQueryable<SubjectDTO>>(data).ToList();
        }

        public async Task<List<SemesterDTO>> GetSemesterByStudent(Guid studentId)
        {
            var data = base.Repository.Entities
                .Find(studentId).StudentSemesters.Select(ss =>
                ss.Semester).ToList();
            return Mapper.Map<List<SemesterDTO>>(data!);
        }
    }
}
