using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface ITeacherRepository : IAppGenericDefaultKeyRepository<Teacher>
    {
        Task<Teacher> GetTeacherByClass(Guid? classId);

    }
}
