using domain;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class SemesterRepository : AppGenericDefaultKeyRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AppDbContext context) : base(context)
        {
        }

        public StudentSemester GetCurrentSemester(Guid studentId)
        {
            return Context.StudentSemesters.Include(ss => ss.Semester).FirstOrDefault(ss => ss.IsNow == true && ss.StudentId.Equals(studentId));
        }
        public StudentSemester GetStudentSemester(Guid studentId, Guid semesterId)
        {
            return Context.StudentSemesters.FirstOrDefault(ss => ss.SemesterId.Equals(semesterId) && ss.StudentId.Equals(studentId));
        }
        public List<Semester> GetSemesterByStudent(Guid studentId)
        {
            return Context.StudentSemesters.Where(ss => ss.StudentId.Equals(studentId)).Select(ss => ss.Semester).ToList();
        }
    }
}
