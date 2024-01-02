using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface IMajorRepository : IAppGenericDefaultKeyRepository<Major>
    {
        Task<Major> GetMajorByCode(string code);
        Major GetMajorByStudent(Guid studentId);
    }
}
