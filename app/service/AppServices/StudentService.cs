using AutoMapper;
using domain;
using domain.shared.AppSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Student;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;
using System.Dynamic;

namespace service.AppServices
{
    public class StudentService : AppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>, IStudentService
    {
        readonly JwtConfiguration _jwtConfiguration;
        private readonly IStudentRepository _studentRepository;
        private readonly IMajorRepository _majorRepository;
        private readonly ISemesterRepository _semesterRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ITeacherRepository _teacherRepository;
        public StudentService(IStudentRepository genericRepository,ITeacherRepository teacherRepository, IRoomRepository roomRepository, ISubjectRepository subjectRepository, ISemesterRepository semesterRepository, IMajorRepository majorRepository, IMapper mapper, IOptions<JwtConfiguration> jwtConfiguration) : base(genericRepository, mapper)
        {
            _studentRepository = genericRepository;
            _majorRepository = majorRepository;
            _semesterRepository = semesterRepository;
            _subjectRepository = subjectRepository;
            _roomRepository = roomRepository;
            _teacherRepository = teacherRepository;
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public async Task ImportStudentsFromExcel(IFormFile file)
        {
            var students = new List<Student>();

            using (var stream = file.OpenReadStream())
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {

                    var student = new Student
                    {
                        Username = worksheet.Cells[row, 1].Value.ToString(),
                        FullName = worksheet.Cells[row, 2].Value.ToString(),
                        Email = worksheet.Cells[row, 3].Value.ToString(),
                        Dob = DateTime.Parse(worksheet.Cells[row, 4].Value.ToString()),
                        Gender = Convert.ToBoolean(worksheet.Cells[row, 5].Value),
                        Phone = worksheet.Cells[row, 6].Value.ToString(),
                        MajorId = _majorRepository.GetMajorByCode(worksheet.Cells[row, 7].Value.ToString()).Result.Id,
                        Major = _majorRepository.GetMajorByCode(worksheet.Cells[row, 7].Value.ToString()).Result
                    };
                    student.Id = Guid.NewGuid();
                    student.Password = Guid.NewGuid().ToString();
                    HashService hashService = new(student.Password, _jwtConfiguration.HashSalt);
                    student.Password = hashService.EncryptedPassword;
                    students.Add(student);
                }
            }

            await _studentRepository.AddRange(students);
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

        public async Task<AttendanceHistory> GetAttendances(Guid studentId, Guid semesterId, Guid subjectId)
        {
            AttendanceHistory attendanceHistory = new();
            var studentSemester = _semesterRepository.GetStudentSemester(studentId,semesterId);
            FeeDetail fee = await _studentRepository.GetFeeDetailBySubject(studentSemester.Id,subjectId);
            attendanceHistory.Class = fee.Class;
            attendanceHistory.Teacher = await _teacherRepository.GetTeacherByClass(fee.ClassId);
            List<Attendance> list = fee.Attendances.ToList();
            attendanceHistory.Attendances.AddRange(list);
            return attendanceHistory;
        }

        public async Task<List<TimeTableDTO>> GetTimeTable(Guid studentId)
        {
            List<TimeTableDTO> result = new();

            var currentSemester = _semesterRepository.GetCurrentSemester(studentId).Semester;
            var fees = await _studentRepository.GetFeeDetails(currentSemester.Id, studentId);

            var year = currentSemester.CreatedAt.Year;
            DateTime startOfTerm = new DateTime(year, currentSemester.StartMonth, currentSemester.StartDay);
            if (currentSemester.StartMonth > currentSemester.EndMonth) { year++; }
            DateTime endOfTerm = new DateTime(year, currentSemester.EndMonth, currentSemester.EndDay);

            foreach (var item in fees)
            {
                TimeTableDTO timeTable = new();
                timeTable.Subject = item.Subject;
                timeTable.StartDate = startOfTerm;
                timeTable.EndDate = endOfTerm;
                timeTable.Room = await _roomRepository.Find(item.Attendances.FirstOrDefault().RoomId);
                List<SlotTimeTableAtWeek> list = await _studentRepository.GetSlotTimeTableAtWeeks(item.Id,studentId);
                timeTable.AtWeek.AddRange(list);
                result.Add(timeTable);
            }
            return result;
        }

        public async Task<List<Slot>> GetSlots()
        {
           return await _studentRepository.GetSlots();
        }
        public async Task<List<Timetable>> GetTimetables()
        {
            return await _studentRepository.GetTimetables();
        }
    }
}
