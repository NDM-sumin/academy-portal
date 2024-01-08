using AutoMapper;
using domain;
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

        readonly IMajorSubjectService majorSubjectService;
        public SubjectService(ISubjectRepository genericRepository,
            IMapper mapper,
            IStudentService studentService, IStudentSemesterService studentSemesterService,
            IMajorSubjectService majorSubjectService) : base(genericRepository, mapper)
        {
            this.studentService = studentService;
            this.majorSubjectService = majorSubjectService;
            this.studentSemesterService = studentSemesterService;
        }



        public async Task<List<SubjectDTO>> GetRegisterableSubjects(Guid studentId)
        {
            var listSubject = new List<SubjectDTO>();
            listSubject.AddRange(studentService.GetFailedSubjects(studentId));

            var student = await studentService.Get(studentId);

            var studentSemester = await studentSemesterService.GetCurrentSemester(studentId);
            if (studentSemester != null)
            {
                var majorSubjects = majorSubjectService.GetSubjectsOfMajorInSemester(student.Major.Id, studentSemester.Semester.NextSemester.Id);
                var subjects = majorSubjects.Select(ms => ms.Subject);
                listSubject.AddRange(subjects);
            }

            return listSubject;
        }

    }
}
