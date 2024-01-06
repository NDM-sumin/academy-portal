using AutoMapper;
using domain;
using domain.shared.AppSettings;
using Microsoft.Extensions.Options;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Teacher;
using service.contract.IAppServices;

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
            entityDto.Id = Guid.NewGuid();
            entityDto.Password = Guid.NewGuid().ToString();
            HashService hashService = new HashService(entityDto.Password, _jwtConfiguration.HashSalt);
            entityDto.Password = hashService.EncryptedPassword;
            return base.Create(entityDto);
        }
    }
}
