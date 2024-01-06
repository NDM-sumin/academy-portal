using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class FeeDetailService : AppCRUDDefaultKeyService<FeeDetailDTO, CreateFeeDetailDTO, CreateFeeDetailDTO, FeeDetail>, IFeeDetailService
    {
        public FeeDetailService(IFeeDetailRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public List<SubjectDTO> GetFailedSubjects(Guid studentId)
        {
            var data = base.Repository.Entities
                    .Where(fd => fd.StudentSemester.StudentId == studentId
                        && fd.StudentSemester.Student.Scores
                            .Where(sc => sc.SubjectComponent.SubjectID == fd.SubjectId)
                            .Sum(sc => sc.Value * sc.SubjectComponent.Weight) < 5
                    )
                    .Select(fd => fd.Subject);
            return Mapper.Map<IQueryable<SubjectDTO>>(data).ToList();

        }
    }
}
