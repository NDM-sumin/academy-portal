using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Major;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class MajorService : AppCRUDDefaultKeyService<MajorDTO, CreateMajorDTO, UpdateMajorDTO, Major>, IMajorService
    {

        public MajorService(IMajorRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }


        public Task<MajorDTO> GetMajorByCode(string code)
        {
            return Task.FromResult(Mapper.Map<MajorDTO>(Repository.Entities.AsNoTracking().FirstOrDefault(m => m.MajorCode.Equals(code))));
        }

        public async Task<List<SubjectDTO>> GetSubjectByMajor(Guid majorId)
        {
            return Mapper.Map<List<SubjectDTO>>((await (Repository as IMajorRepository).Find(majorId)).MajorSubjects.Select(ms => ms.Subject));
        }
    }
}
