using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface IStudentSemesterRepository : IAppGenericDefaultKeyRepository<StudentSemester>
    {
        Task<StudentSemester> Find(Guid semesterId, Guid studentId);
    }
}
