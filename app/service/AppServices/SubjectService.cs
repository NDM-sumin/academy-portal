using AutoMapper;
using domain;
using domain.shared.Exceptions;
using repository.AppRepositories;
using repository.contract.IAppRepositories;
using repository.contract.IAppRepositories.Base;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.DTOs.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class SubjectService : AppCRUDDefaultKeyService<SubjectDTO, CreateSubjectDTO, UpdateSubjectDTO, Subject>, ISubjectService
    {
        public ISubjectRepository _subjectRepository;
        public ISemesterRepository _semesterRepository;
        public IMajorRepository _majorRepository;
        public IScoreRepository _scoreRepository;

        public SubjectService(ISubjectRepository genericRepository,IScoreRepository scoreRepository, ISemesterRepository semesterRepository, IMajorRepository majorRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            _subjectRepository = genericRepository;
            _semesterRepository = semesterRepository;
            _majorRepository = majorRepository;
            _scoreRepository = scoreRepository;
        }

        public List<SubjectDTO> GetRegisterSubjects(Guid studentId)
        {
            var listSubject = new List<SubjectDTO>();
            var major = _majorRepository.GetMajorByStudent(studentId);

            listSubject.AddRange((IEnumerable<SubjectDTO>)_scoreRepository.getOweSubject(studentId));

            var semester = _semesterRepository.getCurrentSemester(studentId);
            if (semester != null)
            {
                var majorSubjects = _subjectRepository.GetMajorSubjects(semester.Id, major.Id);
                foreach (var item in majorSubjects)
                {
                    var subject = new SubjectDTO
                    {
                        Id = item.Subject.Id,
                        SubjectName = item.Subject.SubjectName,
                        SubjectCode = item.Subject.SubjectCode,
                    };

                    listSubject.Add(subject);
                }
            }
            else
            {
                throw new ServerException(4000);
            }

            return listSubject;
        }
    }
}
