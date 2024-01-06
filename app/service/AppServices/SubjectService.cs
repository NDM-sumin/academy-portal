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
        readonly ISemesterService _semesterService;
        readonly IFeeDetailService _feeDetailService;
        readonly IStudentRepository _studentRepository;
        readonly IMajorSubjectService majorSubjectService;
        public SubjectService(ISubjectRepository genericRepository,
            ISemesterService semesterService,
            IMapper mapper,
            IFeeDetailService feeDetailService,
            IStudentRepository studentRepository,
            IMajorSubjectService majorSubjectService) : base(genericRepository, mapper)

        {
            _semesterService = semesterService;
            _feeDetailService = feeDetailService;
            _studentRepository = studentRepository;
            this.majorSubjectService = majorSubjectService;
        }


        public async Task<List<SubjectDTO>> GetRegisterableSubjects(Guid studentId)
        {
            var listSubject = new List<SubjectDTO>();
            listSubject.AddRange(_feeDetailService.GetFailedSubjects(studentId));

            var student = await _studentRepository.Find(studentId);

            var semester = _semesterService.GetCurrentSemester(studentId);
            if (semester != null)
            {
                var majorSubjects = majorSubjectService.GetSubjectsOfMajorInSemester(semester.NextSemester.Id, student.Major.Id);
                var subjects = majorSubjects.Select(ms => ms.Subject);
                listSubject.AddRange(subjects);
            }

            return listSubject;
        }
    }
}
