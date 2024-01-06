using AutoMapper;
using domain;
using domain.shared.AppSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Major;
using service.contract.DTOs.Student;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class StudentService : AppCRUDDefaultKeyService<StudentDTO, CreateStudentDTO, UpdateStudentDTO, Student>, IStudentService
    {
        readonly JwtConfiguration _jwtConfiguration;
        readonly IMajorService _majorService;
        readonly ISemesterService _semesterService;
        readonly IRoomRepository _roomRepository;
        readonly IStudentSemesterRepository _studentSemesterRepository;
        public StudentService(IStudentRepository genericRepository,
            IRoomRepository roomRepository,
            ISemesterService semesterService,
            IMajorService majorService,
            IMapper mapper,
            IOptions<JwtConfiguration> jwtConfiguration,
            IStudentSemesterRepository studentSemesterRepository) : base(genericRepository, mapper)
        {
            _majorService = majorService;
            _semesterService = semesterService;
            _roomRepository = roomRepository;
            _jwtConfiguration = jwtConfiguration.Value;
            _studentSemesterRepository = studentSemesterRepository;
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

        public async Task<List<TimeTableDTO>> GetTimeTable(Guid studentId)
        {
            throw new NotImplementedException();
        }
    }
}
