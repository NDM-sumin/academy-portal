using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Attendance;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class FeeDetailService : AppCRUDDefaultKeyService<FeeDetailDTO, CreateFeeDetailDTO, CreateFeeDetailDTO, FeeDetail>, IFeeDetailService
    {
        readonly IAttedanceRepository attedanceRepository;
        readonly IStudentSemesterRepository studentSemesterRepository;
        readonly ISubjectRepository subjectRepository;
        public FeeDetailService(ISubjectRepository subjectRepository, IStudentSemesterRepository studentSemesterRepository, IAttedanceRepository attedanceRepository, IFeeDetailRepository genericRepository,
         IMapper mapper) : base(genericRepository, mapper)
        {
            this.attedanceRepository = attedanceRepository;
            this.studentSemesterRepository = studentSemesterRepository;
            this.subjectRepository = subjectRepository;
        }

        public async Task<List<FeeDetailDTO>> GetByStudent(Guid studentId, Guid semesterId)
        {
            var result = await base.Repository.Entities.Include(fd => fd.Subject).Include(fd => fd.Attendances).Include(fd => fd.Class)
                .Where(fd => fd.StudentSemester.SemesterId == semesterId && fd.StudentSemester.StudentId == studentId).ToListAsync();
            return Mapper.Map<List<FeeDetailDTO>>(result);

        }

        public async Task<(FeeDetailDTO, List<AttendanceDTO>)> GetByStudentAndSubject(Guid studentId, Guid semesterId, Guid subjectId)
        {
            var result = await base.Repository.Entities.Include(fd => fd.Class).ThenInclude(c => c.Teacher).Include(fd => fd.Attendances)
            .FirstOrDefaultAsync(fd => fd.StudentSemester.SemesterId == semesterId
            && fd.StudentSemester.StudentId == studentId
            && fd.SubjectId == subjectId
            );
            var attendance = attedanceRepository.Entities.Include(a => a.Room)
                             .Include(a => a.SlotTimeTableAtWeek).ThenInclude(st => st.Slot)
                             .Include(a => a.FeeDetail).Where(a => a.FeeDetailId == result.Id).ToList();
            return (Mapper.Map<FeeDetailDTO>(result), (Mapper.Map<List<AttendanceDTO>>(attendance)));
        }

        public async Task<FeeDetailDTO> GetByClass(Guid classId)
        {
            var result = await base.Repository.GetAll().Result.Include(fd => fd.Subject).Include(fd => fd.Attendances).FirstOrDefaultAsync(fd => fd.ClassId == classId);
            return Mapper.Map<FeeDetailDTO>(result);
        }


        public async Task AddFee()
        {
            List<FeeDetail> result = new();
            var studentSemesters = studentSemesterRepository.GetAll().Result.Where(ss => ss.IsNow == true);
            var subject = subjectRepository.GetAll().Result.FirstOrDefault(s => s.Id.Equals(Guid.Parse("0DE01667-EDCD-4D7F-A1E2-2636BCA248E1")));
            foreach (var item in studentSemesters)
            {
                FeeDetail feeDetail = new FeeDetail();
                feeDetail.Id = Guid.NewGuid();
                feeDetail.StudentSemesterId = item.Id;
                feeDetail.StudentSemester = item;
                feeDetail.DueDate = DateTime.Now;
                feeDetail.PayDate = DateTime.Now;
                feeDetail.Amount = 30000;
                feeDetail.PaymentTransactionId = Guid.Parse("EA36BA11-F466-48F1-A5FF-180758012355");
                feeDetail.SubjectId = Guid.Parse("0DE01667-EDCD-4D7F-A1E2-2636BCA248E1");
                feeDetail.Subject = subject;
                result.Add(feeDetail);
            }
            this.Repository.AddRange(result);
        }

    }
}
