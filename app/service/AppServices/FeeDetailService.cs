using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class FeeDetailService : AppCRUDDefaultKeyService<FeeDetailDTO, CreateFeeDetailDTO, CreateFeeDetailDTO, FeeDetail>, IFeeDetailService
    {
        public FeeDetailService(IFeeDetailRepository genericRepository,
         IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public async Task<List<FeeDetailDTO>> GetByStudent(Guid studentId, Guid semesterId)
        {
            var result = await base.Repository.Entities
                .Where(fd => fd.StudentSemester.SemesterId == semesterId && fd.StudentSemester.StudentId == studentId).ToListAsync();
            return Mapper.Map<List<FeeDetailDTO>>(result);

        }

        public async Task<FeeDetailDTO> GetByStudentAndSubject(Guid semesterId, Guid studentId, Guid subjectId)
        {
            var result = await base.Repository.Entities
            .FirstOrDefaultAsync(fd => fd.StudentSemester.SemesterId == semesterId
            && fd.StudentSemester.StudentId == studentId
            && fd.SubjectId == subjectId
            );
            return Mapper.Map<FeeDetailDTO>(result);


        }


    }
}
