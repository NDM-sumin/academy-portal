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
        public FeeDetailService(IAttedanceRepository attedanceRepository, IFeeDetailRepository genericRepository,
         IMapper mapper) : base(genericRepository, mapper)
        {
            this.attedanceRepository = attedanceRepository;
        }

        public async Task<List<FeeDetailDTO>> GetByStudent(Guid studentId, Guid semesterId)
        {
            var result = await base.Repository.Entities.Include(fd => fd.Subject).Include(fd => fd.Attendances)
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



    }
}
