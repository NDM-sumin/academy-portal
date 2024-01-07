using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Score;
using service.contract.DTOs.Slot;
using service.contract.DTOs.SubjectComponent;
using service.contract.IAppServices;
using System.Collections.Generic;

namespace service.AppServices
{
    public class SubjectComponentService : AppCRUDDefaultKeyService<SubjectComponentDTO, SubjectComponent, SubjectComponent, SubjectComponent>, ISubjectComponentService
    {
        public SubjectComponentService(ISubjectComponentRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
        public async Task<List<SubjectComponentDTO>> GetByStudentAndSubject(Guid studentId, Guid subjectId)
        {
            var result = await base.Repository.Entities
            .Where(sc => sc.SubjectID == subjectId
            && sc.Scores.Any(s => s.StudentId == studentId)
            ).ToListAsync();
            return Mapper.Map<List<SubjectComponentDTO>>(result);
        }
    }
}