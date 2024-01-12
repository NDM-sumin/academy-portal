using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using repository.AppRepositories;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.Class;
using service.contract.DTOs.Score;
using service.contract.DTOs.Student;
using service.contract.DTOs.SubjectComponent;
using service.contract.DTOs.Teacher;
using service.contract.IAppServices;
using System;

namespace service.AppServices
{
    public class ClassService : AppCRUDDefaultKeyService<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>, IClassService
    {
        readonly IFeeDetailRepository feeDetailRepository;
        readonly IScoreRepository scoreRepository;
        readonly ISubjectRepository subjectRepository;
        readonly IAttedanceRepository attedanceRepository;

        public ClassService(IScoreRepository scoreRepository, IAttedanceRepository attedanceRepository, ISubjectRepository subjectRepository, IFeeDetailRepository feeDetailRepository, IClassRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            this.feeDetailRepository = feeDetailRepository;
            this.scoreRepository = scoreRepository;
            this.subjectRepository = subjectRepository;
            this.attedanceRepository = attedanceRepository;
        }
        public async Task<List<StudentAttendance>> GetAttendancesByClass(Guid classId, DateTime dateTime)
        {
            var result = await attedanceRepository.GetAll().Result
               .Include(a => a.FeeDetail)
                   .ThenInclude(fd => fd.StudentSemester)
                       .ThenInclude(ss => ss.Student)
               .Where(a => a.FeeDetail.ClassId == classId && a.Date == dateTime)
               .Select(a => new StudentAttendance
               {
                   student = new StudentDTO
                   {
                       Id = a.FeeDetail.StudentSemester.Student.Id,
                       FullName = a.FeeDetail.StudentSemester.Student.FullName,
                   },
                   attendance = new AttendanceDTO
                   {
                       Id = a.Id,
                       IsAttendance = a.IsAttendance,
                   }
               })
               .ToListAsync();

            return Mapper.Map<List<StudentAttendance>>(result);
        }


        public async Task<TeacherDTO> GetTeacher(Guid classId)
        {
            return Mapper.Map<TeacherDTO>((await (Repository as IClassRepository).Find(classId)).Teacher);
        }

        public async Task<List<ClassDTO>> GetClassesByTeacher(Guid teacherId)
        {
            var result = base.Repository.GetAll().Result.Include(c => c.FeeDetails).ThenInclude(fd => fd.StudentSemester).Where(c => c.TeacherId == teacherId).ToList();
            return Mapper.Map<List<ClassDTO>>(result);
        }

        public async Task<List<DateTime?>> GetDates(Guid classId)
        {
            return await attedanceRepository.GetAll().Result
               .Include(a => a.FeeDetail)
               .Where(a => a.FeeDetail.ClassId == classId).Select(a => a.Date).ToListAsync();
        }

        public async Task<List<StudentScoreDTO>> GetStudentsByClass(Guid classId)
        {
            var result = await feeDetailRepository.GetAll().Result
                     .Include(fd => fd.StudentSemester)
                     .ThenInclude(ss => ss.Student)
                     .Include(fd => fd.Subject)
                         .ThenInclude(s => s.SubjectComponents)
                                     .Where(fd => fd.ClassId == classId)
                .GroupBy(fd => new { fd.StudentSemester.StudentId, fd.SubjectId })
                     .Select(group => new StudentScoreDTO
                     {
                         StudentId = group.First().StudentSemester.Student.Id,
                         StudentName = group.First().StudentSemester.Student.FullName,
                         SubjectComponents = group.First().Subject.SubjectComponents
                            .Select(sc => new SubjectComponentDTO
                            {
                                Id = sc.Id,
                                Name = sc.Name,
                                Weight = sc.Weight,
                                Comment = sc.Comment,
                                SubjectID = group.Key.SubjectId,
                                Scores = scoreRepository.Entities
                                    .Where(s => s.StudentId == group.Key.StudentId && s.SubjectComponentID == sc.Id)
                                    .Select(s => new ScoreDTO
                                    {
                                        Value = s.Value,
                                        SubjectComponentID = s.SubjectComponentID,
                                        StudentId = s.StudentId
                                    })
                                    .ToList()
                            })
                            .ToList()
                     })
                    .ToListAsync();
            return result;
        }

        public async Task<List<SubjectComponentDTO>> GetSubjectComponentsByClass(Guid classId)
        {
            var result = subjectRepository.GetAll().Result.Include(s => s.FeeDetails).Include(s => s.SubjectComponents).
                Where(s => s.FeeDetails.Any(fd => fd.ClassId == classId))
                   .SelectMany(s => s.SubjectComponents)
                    .ToList();

            return Mapper.Map<List<SubjectComponentDTO>>(result);
        }

        public async Task SaveAttendance(List<TakeAttendance> result)
        {
            foreach (var item in result)
            {
                var attendance = attedanceRepository.GetAll().Result.FirstOrDefault(a => a.Id == item.AttendanceId);
                attendance.IsAttendance = item.IsAttendance;
                attedanceRepository.Update(attendance);
            }
        }
        public async Task SaveScores(List<TakeScore> result)
        {
            foreach (var item in result)
            {
                foreach (var subjectComponent in item.Scores)
                {
                    var score = scoreRepository.GetAll().Result.Include(s => s.SubjectComponent).
                        Where(s => s.SubjectComponent.Name.Equals(subjectComponent.Name) && s.StudentId == item.StudentId)
                        .OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                    score.Value = string.IsNullOrEmpty(subjectComponent.Value) ? (double?)null : double.Parse(subjectComponent.Value);
                    scoreRepository.Update(score);
                }
            }
        }
    }
}
