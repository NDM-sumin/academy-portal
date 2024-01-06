using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Class;
using service.contract.DTOs.Teacher;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class ClassService : AppCRUDDefaultKeyService<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>, IClassService
    {
        public ClassService(IClassRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public async Task<TeacherDTO> GetTeacher(Guid classId)
        {
            return Mapper.Map<TeacherDTO>((await (Repository as IClassRepository).Find(classId)).Teacher);
        }
    }
}
