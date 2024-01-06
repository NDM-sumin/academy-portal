using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface ISemesterRepository : IAppGenericDefaultKeyRepository<Semester>
    {
        StudentSemester GetCurrentSemester(Guid studentId);
        StudentSemester GetStudentSemester(Guid studentId, Guid semesterId);
    }
}
