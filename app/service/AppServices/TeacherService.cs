using AutoMapper;
using domain;
using domain.shared.AppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Class;
using service.contract.DTOs.Room;
using service.contract.DTOs.Score;
using service.contract.DTOs.SlotTimeTableAtWeek;
using service.contract.DTOs.Student;
using service.contract.DTOs.SubjectComponent;
using service.contract.DTOs.Teacher;
using service.contract.DTOs.Timetable;
using service.contract.IAppServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace service.AppServices
{
    public class TeacherService : AppCRUDDefaultKeyService<TeacherDTO, CreateTeacherDTO, UpdateTeacherDTO, Teacher>, ITeacherService
    {
        readonly JwtConfiguration _jwtConfiguration;
        readonly IClassService classService;
        readonly IFeeDetailService feeDetailService;
        readonly IFeeDetailRepository feeDetailRepository;
        readonly IScoreRepository scoreRepository;
        readonly IStudentSemesterRepository studentSemesterRepository;
        readonly IAttendanceService attendanceService;
        public TeacherService(IAttendanceService attendanceService, IScoreRepository scoreRepository, IStudentSemesterRepository studentSemesterRepository, IFeeDetailRepository feeDetailRepository, IFeeDetailService feeDetailService, IClassService classService, ITeacherRepository genericRepository, IMapper mapper, IOptions<JwtConfiguration> jwtConfiguration) : base(genericRepository, mapper)
        {
            _jwtConfiguration = jwtConfiguration.Value;
            this.classService = classService;
            this.feeDetailService = feeDetailService;
            this.attendanceService = attendanceService;
            this.feeDetailRepository = feeDetailRepository;
            this.studentSemesterRepository = studentSemesterRepository;
            this.scoreRepository = scoreRepository;
        }

        public override Task<TeacherDTO> Create(CreateTeacherDTO entityDto)
        {
            entityDto.Id = Guid.NewGuid();
            entityDto.Password = Guid.NewGuid().ToString();
            HashService hashService = new HashService(entityDto.Password, _jwtConfiguration.HashSalt);
            entityDto.Password = hashService.EncryptedPassword;
            return base.Create(entityDto);
        }

        public async Task<List<TeacherTimetableDto>> GetTimeTable(Guid teacherId)
        {
            List<TeacherTimetableDto> result = new();
            var fees = (await feeDetailService.GetByTeacher(teacherId));
            foreach (var item in fees)
            {



                var timetables = item.Attendances
                         .GroupBy(a => a.SlotTimeTableAtWeekId)
                         .Select(g => g.First().SlotTimeTableAtWeek)
                     .Select(Mapper.Map<SlotTimeTableAtWeekDTO>)
                     .GroupBy(sc => new { sc.TimetableId, sc.SlotId })
                             .Select(group => group.First())
                             .ToList();


                var teacherTimetable = new TeacherTimetableDto
                {
                    StartDate = item.Class.StartDate,
                    EndDate = item.Class.EndDate,
                    Class = item.Class,
                    Subject = item.Subject,
                    Room = item.Attendances.FirstOrDefault()?.Room
                };
                teacherTimetable.AtWeek.AddRange(Mapper.Map<List<SlotTimeTableAtWeekDTO>, List<AtWeekDto>>(timetables));
                result.Add(teacherTimetable);
            }
            string a = JsonSerializer.Serialize(result, new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles });
            return result;
        }

        public async Task<List<ClassDTO>> GetClassByTeacher(Guid teacherId)
        {
            var result = base.Repository.GetAll().Result.Include(t => t.Classes).Where(t => t.Id == teacherId).SelectMany(t => t.Classes).AsEnumerable().ToList();
            return Mapper.Map<List<ClassDTO>>(result);
        }

    }
}
