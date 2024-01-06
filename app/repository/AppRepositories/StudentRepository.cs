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
        public async Task<FeeDetail> GetFeeDetailBySubject(Guid studentSemesterId, Guid subjectId)
        {
            var studentSemester = Context.StudentSemesters.FirstOrDefault(ss => ss.Id.Equals(studentSemesterId));
            return await Context.FeeDetails.Include(fd => fd.Subject).Include(fd => fd.Class).FirstOrDefaultAsync(fd => fd.SubjectId.Equals(subjectId) && fd.StudentSemesterId.Equals(studentSemester.Id));

        }

        public async Task<List<SlotTimeTableAtWeek>?> GetSlotTimeTableAtWeeks(Guid feeDetailId, Guid studentId)
        {
            List<SlotTimeTableAtWeek> result = new();
            var currentSemester = Context.StudentSemesters.Include(ss => ss.Semester).FirstOrDefault(ss => ss.IsNow == true && ss.StudentId.Equals(studentId)).Semester;
            var year = currentSemester.CreatedAt.Year;
            DateTime startOfTerm = new DateTime(year, currentSemester.StartMonth, currentSemester.StartDay);
            if (currentSemester.StartMonth > currentSemester.EndMonth) { year++; }
            DateTime endOfTerm = new DateTime(year, currentSemester.EndMonth, currentSemester.EndDay);

            DateTime currentDate = DateTime.Now;

            if (currentDate >= startOfTerm && currentDate <= endOfTerm)
            {
                int totalDays = (int)(currentDate - startOfTerm).TotalDays;
                int currentWeek = totalDays / 7 + 1;

                result = await Context.SlotTimeTableAtWeeks.Include(staw => staw.Week).Include(staw => staw.Timetable).Include(staw => staw.Slot).Where(staw => staw.Week.WeekName.Equals(currentWeek)).ToListAsync();
            }
            return result;
        }

        public async Task<List<Slot>> GetSlots()
        {
            return await Context.Slots.ToListAsync();
        }

        public async Task<List<Timetable>> GetTimetables()
        {
            return await Context.Timetables.ToListAsync();
        }
    }
}
