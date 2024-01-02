using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface ISemesterRepository : IAppGenericDefaultKeyRepository<Semester>
    {
        Semester getCurrentSemester(Guid studentId);
    }
}
