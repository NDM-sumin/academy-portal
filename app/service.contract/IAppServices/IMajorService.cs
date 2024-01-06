using domain;
using service.contract.DTOs.Major;
using service.contract.DTOs.Subject;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IMajorService : IAppCRUDDefaultKeyService<MajorDTO, CreateMajorDTO, UpdateMajorDTO, Major>
    {
        Task<List<SubjectDTO>> GetSubjectByMajor(Guid majorId);
        Task<MajorDTO> GetMajorByCode(string code);
    }
}
