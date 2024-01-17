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
            var classes = (await classService.GetClassesByTeacher(teacherId));
            foreach (var item in classes)
            {
                var fee = await feeDetailService.GetByClass(item.Id);
                
                var feeDetail = feeDetailRepository.GetAll().Result
                    .Include(fd => fd.Attendances)
                        .ThenInclude(a => a.SlotTimeTableAtWeek)
                        .ThenInclude(staw => staw.Slot)
                        .ThenInclude(staw => staw.SlotTimeTableAtWeeks)
                        .ThenInclude(staw => staw.Week)
                        .ThenInclude(staw => staw.SlotTimeTableAtWeeks)
                        .ThenInclude(staw => staw.Timetable)
                    .Include(fd => fd.Attendances)
                        .ThenInclude(a => a.Room)
                    .Where(fd => fd.Id == fee.Id).ToList();

                var timetables = feeDetail
                     .SelectMany(fd => fd.Attendances
                         .GroupBy(a => a.SlotTimeTableAtWeekId)
                         .Select(g => g.First().SlotTimeTableAtWeek))
                     .AsEnumerable()
                     .Select(Mapper.Map<SlotTimeTableAtWeekDTO>)
                     .ToList().GroupBy(sc => new { sc.TimetableId, sc.SlotId })
                             .Select(group => group.First())
                             .ToList();


                var teacherTimetable = new TeacherTimetableDto
                {
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Class = item,
                    Subject = fee.Subject,
                    Room = Mapper.Map<RoomDTO>(feeDetail
                .SelectMany(fd => fd.Attendances
                    .GroupBy(a => a.Room)
                    .Select(g => g.FirstOrDefault().Room))
                .FirstOrDefault())
                };
                teacherTimetable.AtWeek.AddRange(Mapper.Map<List<SlotTimeTableAtWeekDTO>, List<AtWeekDto>>(timetables));
                result.Add(teacherTimetable);
            }

            return result;
        }

        public async Task<List<ClassDTO>> GetClassByTeacher(Guid teacherId)
        {
            var result = base.Repository.GetAll().Result.Include(t => t.Classes).Where(t => t.Id == teacherId).SelectMany(t => t.Classes).AsEnumerable().ToList();
            return Mapper.Map<List<ClassDTO>>(result);
        }

    }
}
