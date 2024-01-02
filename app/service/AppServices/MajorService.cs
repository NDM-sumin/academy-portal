using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Major;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class MajorService : AppCRUDDefaultKeyService<MajorDTO, CreateMajorDTO, UpdateMajorDTO, Major>, IMajorService
    {
        private IMajorRepository _majorRepository;
        public MajorService(IMajorRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            _majorRepository = genericRepository;
        }

        public async Task<SubjectDTO> GetSubjectByMajor(Guid majorId)
        {
            return Mapper.Map<SubjectDTO>(await _majorRepository.Find(majorId));
        }
    }
}
