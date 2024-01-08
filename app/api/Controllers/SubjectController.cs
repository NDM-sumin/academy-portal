using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.MajorSubject;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SubjectController : AppCRUDDefaultKeyController<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>
    {
        readonly IStudentSemesterService studentSemesterService;
        readonly IMajorSubjectService majorSubjectService;
        public SubjectController(ISubjectService appCRUDService,
        IStudentSemesterService studentSemesterService,
        IMajorSubjectService majorSubjectService) : base(appCRUDService)
        {
            this.studentSemesterService = studentSemesterService;
            this.majorSubjectService = majorSubjectService;
        }

        public override async Task<SubjectDTO> Create(CreateSubjectDTO entityDto)
        {
            var data = await base.Create(entityDto);
            foreach (var majorId in entityDto.MajorIds)
            {

                await majorSubjectService.Create(new MajorSubjectDto()
                {
                    MajorId = majorId,
                    SemesterId = entityDto.SemesterId,
                    SubjectId = entityDto.Id
                });
            }
            return data;

        }
        public override async Task<SubjectDTO> Update(UpdateSubjectDTO updateSubjectDTO)
        {
            var data = await base.Update(updateSubjectDTO);
            await majorSubjectService.DeleteBySubjectId(updateSubjectDTO.Id);
            foreach (var majorId in updateSubjectDTO.MajorIds)
            {

                await majorSubjectService.Create(new MajorSubjectDto()
                {
                    MajorId = majorId,
                    SemesterId = updateSubjectDTO.SemesterId,
                    SubjectId = updateSubjectDTO.Id
                });
            }
            return data;
        }

        [HttpGet("GetRegisterableSubjects")]
        public async Task<List<SubjectDTO>> GetRegisterableSubjects()
        {
            return await (appCRUDService as ISubjectService).GetRegisterableSubjects(this.GetUserId());
        }

        [HttpGet("GetSubjects/{semesterId}/{studentId}")]
        public async Task<List<SubjectDTO>> GetSubjects(Guid semesterId, Guid studentId)
        {
            return await studentSemesterService.GetSubjects(semesterId, studentId);
        }

    }
}
