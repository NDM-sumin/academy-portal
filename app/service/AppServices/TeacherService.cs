using AutoMapper;
using domain;
using domain.shared.AppSettings;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Options;
using repository.AppRepositories;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.DTOs.Student;
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
        readonly JwtConfiguration _jwtConfiguration;
        public TeacherService(ITeacherRepository genericRepository, IMapper mapper, IOptions<JwtConfiguration> jwtConfiguration) : base(genericRepository, mapper)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public override Task<TeacherDTO> Create(CreateTeacherDTO entityDto)
        {
            entityDto.Password = Guid.NewGuid().ToString();
            HashService hashService = new HashService(entityDto.Password, _jwtConfiguration.HashSalt);
            entityDto.Password = hashService.EncryptedPassword;
            return base.Create(entityDto);
        }
    }
}
