using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface ISubjectRepository : IAppGenericDefaultKeyRepository<Subject>
    {
        List<MajorSubject> GetMajorSubjects(Guid majorId, Guid semesterId);
    }
}
