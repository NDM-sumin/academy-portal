using AutoMapper;
using domain;
using entityframework.Extensions;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class SubjectService : AppCRUDDefaultKeyService<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>, ISubjectService
    {
        readonly IStudentService studentService;
        readonly IStudentSemesterService studentSemesterService;
        readonly IFeeDetailService feeDetailService;
        readonly IMajorSubjectService majorSubjectService;
        public SubjectService(ISubjectRepository genericRepository,
            IMapper mapper,
            IStudentService studentService, IStudentSemesterService studentSemesterService,
            IMajorSubjectService majorSubjectService,
            IFeeDetailService feeDetailService) : base(genericRepository, mapper)
        {
            this.studentService = studentService;
            this.majorSubjectService = majorSubjectService;
            this.studentSemesterService = studentSemesterService;
            this.feeDetailService = feeDetailService;
        }

        public async Task<List<SubjectDTO>> GetRegisterableSubjects(Guid studentId)
        {



            var listSubject = new List<SubjectDTO>();
            listSubject.AddRange(studentService.GetFailedSubjects(studentId));

            var student = await studentService.Get(studentId);

            var studentSemester = await studentSemesterService.GetCurrentSemester(studentId);
            if (studentSemester?.Semester != null)
            {
                var majorSubjects = majorSubjectService.GetSubjectsOfMajorInSemester(student.Major.Id, studentSemester.Semester.Id);
                var subjects = majorSubjects.Select(ms => ms.Subject);
                var feeDetailRegistered = await feeDetailService.GetByStudent(studentId, studentSemester.SemesterId);


                listSubject.AddRange(subjects.Where(s => !feeDetailRegistered.Select(f => f.SubjectId).Contains(s.Id)));
            }

            return listSubject;
        }

    }
}
