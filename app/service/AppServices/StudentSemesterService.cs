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
        public StudentSemesterService(IStudentSemesterRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public async Task<List<SubjectDTO>> GetSubjects(Guid semesterId, Guid studentId)
        {
            var data = (await Repository.Entities
                .FirstOrDefaultAsync(ss => ss.SemesterId == semesterId && ss.StudentId == studentId))?
                .FeeDetails
                .Select(fd => fd.Subject)
                ?? Enumerable.Empty<Subject>();
            return Mapper.Map<List<SubjectDTO>>(data);
        }

    }
}
