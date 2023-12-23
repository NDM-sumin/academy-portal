using AutoMapper;
using domain;
using repository.AppRepositories;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.DTOs.Major;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class MajorService : AppCRUDDefaultKeyService<MajorDTO, CreateMajorDTO, UpdateMajorDTO, Major>, IMajorService
    {
        public MajorService(IMajorRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
