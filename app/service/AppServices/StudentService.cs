using AutoMapper;
using domain;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class StudentService : AppCRUDDefaultKeyService<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Student>, IStudentService
    {
        public StudentService(IAppGenericDefaultKeyRepository<Student> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
