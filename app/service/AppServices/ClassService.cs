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
using System.Collections.Immutable;
using System.Xml.Linq;

namespace service.AppServices
{
    public class ClassService : AppCRUDDefaultKeyService<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>, IClassService
    {
        readonly IFeeDetailRepository feeDetailRepository;
        readonly IScoreRepository scoreRepository;
        readonly ISubjectRepository subjectRepository;
        readonly IAttedanceRepository attedanceRepository;
        readonly IStudentRepository studentRepository;
        readonly IClassRepository classRepository;
        public ClassService(IClassRepository classRepository, IStudentRepository studentRepository, IScoreRepository scoreRepository, IAttedanceRepository attedanceRepository, ISubjectRepository subjectRepository, IFeeDetailRepository feeDetailRepository, IClassRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            this.feeDetailRepository = feeDetailRepository;
            this.scoreRepository = scoreRepository;
            this.subjectRepository = subjectRepository;
            this.attedanceRepository = attedanceRepository;
            this.studentRepository = studentRepository;
            this.classRepository = classRepository;
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

        public async Task ClassForNewSemester()
        {
            var subjects = subjectRepository.GetAll().Result.Include(s => s.FeeDetails).ThenInclude(fd => fd.StudentSemester).ThenInclude(ss => ss.Semester).ToList();
            var currentSemester = subjects.FirstOrDefault().FeeDetails.Where(fd => fd.StudentSemester.IsNow == true).Select(fd => fd.StudentSemester.Semester).FirstOrDefault();

            foreach (var subject in subjects)
            {
                var fees = feeDetailRepository.GetAll().Result.Include(fd => fd.StudentSemester).ThenInclude(ss => ss.Student).Where(fd => fd.StudentSemester.IsNow == true && fd.SubjectId == subject.Id && fd.ClassId == null).ToList();
                var index = 0;
                while (fees.Any())
                {
                    Class newClass = new()
                    {
                        Id = Guid.NewGuid(),
                        StartDate = new DateTime(DateTime.Now.Year, currentSemester.StartMonth, currentSemester.StartDay),
                        EndDate = new DateTime(DateTime.Now.Year, currentSemester.EndMonth, currentSemester.EndDay),
                        ClassCode = $"{subject.SubjectCode}_{index}"
                    };
                    classRepository.Create(newClass);

                    for (int i = 0; i < 30; i++)
                    {
                        FeeDetail feeDetail = fees[i];
                        feeDetail.Class = newClass;
                        feeDetail.ClassId = newClass.Id;
                        feeDetailRepository.Update(feeDetail);
                    }

                    index++;
                }
            }
        }

        public async Task<TeacherDTO> GetTeacher(Guid classId)
        {
            return Mapper.Map<TeacherDTO>((await (Repository as IClassRepository).Find(classId)).Teacher);
        }

        public async Task<List<ClassDTO>> GetClassesByTeacher(Guid teacherId)
        {
            var result = base.Repository.GetAll().Result.Include(c => c.FeeDetails).ThenInclude(fd => fd.StudentSemester).Where(c => c.TeacherId == teacherId && c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now).ToList();
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

        public async Task<ClassInformation> GetClassInformation(Guid classId)
        {
            return classRepository.GetAll().Result.Include(c => c.Teacher)
                .Include(c => c.FeeDetails).ThenInclude(fd => fd.StudentSemester).ThenInclude(ss => ss.Student).ThenInclude(s => s.Major)
                .Include(c => c.FeeDetails).ThenInclude(fd => fd.Subject).
                Select(c => new ClassInformation()
                {
                    ClassCode = c.ClassCode,
                    TeacherName = c.Teacher.FullName,
                    SubjectName = c.FeeDetails.FirstOrDefault().Subject.SubjectName,
                    Students = Mapper.Map<List<StudentDTO>>(c.FeeDetails.Select(fd => fd.StudentSemester.Student).ToList())
                }).FirstOrDefault();
        }
    }
}
