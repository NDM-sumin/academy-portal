using domain;
using service.contract.DTOs.MajorSubject;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IMajorSubjectService : IAppCRUDDefaultKeyService<MajorSubjectDto, MajorSubjectDto,  MajorSubjectDto, MajorSubject>
    {
        List<MajorSubjectDto> GetSubjectsOfMajorInSemester(Guid majorId, Guid semesterId);

    }
}
