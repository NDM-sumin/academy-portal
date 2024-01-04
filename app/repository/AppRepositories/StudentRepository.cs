using domain;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class StudentRepository : AppGenericDefaultKeyRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddRange(List<Student> students)
        {
            await base.Entities.AddRangeAsync(students);
        }

        public async Task<List<FeeDetail>> GetFeeDetails(Guid semesterId, Guid studentId)
        {
            var studentSemester = Context.StudentSemesters.FirstOrDefault(ss => ss.StudentId.Equals(studentId) && ss.IsNow == true && ss.SemesterId.Equals(semesterId));
            return await Context.FeeDetails.Include(fd => fd.Subject).Include(fd => fd.Attendances).Where(fd => fd.StudentSemesterId.Equals(studentSemester.Id)).ToListAsync();
        }

        public async Task<List<SlotTimeTableAtWeek>?> GetSlotTimeTableAtWeeks(Guid feeDetailId)
        {
            var result = await Context.SlotTimeTableAtWeeks.Include(staw => staw.Week).Include(staw => staw.Timetable).Include(staw => staw.Slot).Where(staw => staw.FeeDetailId.Equals(feeDetailId)).ToListAsync();
            return result;
        }
    }
}
