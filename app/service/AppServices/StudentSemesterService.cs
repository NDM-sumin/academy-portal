using AutoMapper;
using domain;
using domain.shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.StudentSemester;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class StudentSemesterService : AppCRUDDefaultKeyService<StudentSemesterDto, UpdateStudentSemesterDto, UpdateStudentSemesterDto, StudentSemester>, IStudentSemesterService
    {
        readonly IFeeDetailRepository feeDetailRepository;
        readonly    ISemesterRepository semesterRepository;
        public StudentSemesterService(IFeeDetailRepository feeDetailRepository, 
        IStudentSemesterRepository genericRepository, IMapper mapper,
        ISemesterRepository semesterRepository) : base(genericRepository, mapper)
        {
            this.feeDetailRepository = feeDetailRepository;
            this.semesterRepository = semesterRepository;
        }

        public async Task<List<SubjectDTO>> GetSubjects(Guid semesterId, Guid studentId)
        {
            var studentSemester = (await Repository.Entities.Include(s => s.FeeDetails)
                .FirstOrDefaultAsync(ss => ss.SemesterId == semesterId && ss.StudentId == studentId));
            var data = feeDetailRepository.Entities.Include(fd => fd.Subject).Where(fd => fd.StudentSemesterId == studentSemester.Id).Select(fd => fd.Subject).ToList()
                ?? Enumerable.Empty<Subject>();
            return Mapper.Map<List<SubjectDTO>>(data);
        }
        public async Task<StudentSemesterDto> GetCurrentSemester(Guid studentId)
        {
            List<StudentSemester>? studentSemester = await this.Repository.Entities
            .Include(s => s.Semester)
            .ThenInclude(s => s.NextSemester)
            .ThenInclude(s => s.StudentSemesters)
            .Include(s => s.Student)
                .Where(s => s.StudentId == studentId).AsNoTracking().ToListAsync();
            var data = studentSemester.FirstOrDefault(s => s.IsNow == true);
            return Mapper.Map<StudentSemesterDto>(data!);
        }

        public async Task<StudentSemesterDto> SetNextSemester(Guid studentId)
        {
            var currentSemester = await GetCurrentSemester(studentId);
            //this.Repository.DetachLocalAll();

          

            if(currentSemester != null){
                if (currentSemester.Semester.NextSemester == null)
                {
                    throw new ClientException(5007);
                }
                currentSemester.IsNow = false;
                UpdateStudentSemesterDto updating = Mapper.Map<UpdateStudentSemesterDto>(currentSemester);
                await this.Update(updating);
            }
          
            UpdateStudentSemesterDto creating = new()
            {
                StudentId = studentId,
                IsNow = true,
                SemesterId = currentSemester?.Semester?.NextSemester?.Id ?? semesterRepository.GetFirstSemester().Id
            };
          
            await this.Create(creating);
            return await GetCurrentSemester(studentId);

        }

        public async Task<List<StudentSemesterDto>> SetNextSemester()
        {
            this.Repository.Context.Database.SetCommandTimeout(1000);
            List<StudentSemesterDto> studentSemesterDtos = new();
            foreach (var student in this.Repository.Context.Students)
            {
                try
                {
                    StudentSemesterDto dto = await SetNextSemester(student.Id);
                    studentSemesterDtos.Add(dto);
                }
                catch (ClientException ClientException)
                {
                    if (ClientException.Code != 5007) throw;
                }


            }
            this.Repository.Context.SaveChanges();
            return studentSemesterDtos;
        }
    }
}
