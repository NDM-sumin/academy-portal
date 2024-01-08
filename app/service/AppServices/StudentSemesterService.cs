using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.StudentSemester;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class StudentSemesterService : AppCRUDDefaultKeyService<StudentSemesterDto, StudentSemesterDto, StudentSemesterDto, StudentSemester>, IStudentSemesterService
    {
        readonly IFeeDetailRepository feeDetailRepository;
        public StudentSemesterService(IFeeDetailRepository feeDetailRepository,IStudentSemesterRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            this.feeDetailRepository = feeDetailRepository;
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
            List<StudentSemester>? studentSemester = await this.Repository.Entities.Include(s => s.Semester).ThenInclude(s => s.NextSemester).Include(s => s.Student)
                .Where(s => s.StudentId == studentId).ToListAsync();
            var data = studentSemester.FirstOrDefault(s => s.IsNow == true);
            return Mapper.Map<StudentSemesterDto>(data!);
        }
    }
}
