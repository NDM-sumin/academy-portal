using AutoMapper;
using domain;
using repository.AppRepositories;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.DTOs.Subject;
using service.contract.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class TeacherService : AppCRUDDefaultKeyService<TeacherDTO, CreateTeacherDTO, UpdateTeacherDTO, Teacher>, ITeacherService
    {
        public TeacherService(ITeacherRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
