using domain;
using domain.shared.Exceptions;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class StudentSemesterRepository : AppGenericDefaultKeyRepository<StudentSemester>, IStudentSemesterRepository
    {
        public StudentSemesterRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<StudentSemester> Find(Guid semesterId, Guid studentId)
        {
            var result = await Entities.FirstOrDefaultAsync(ss => ss.SemesterId == semesterId && ss.StudentId == studentId)
            ?? throw new ClientException(4040);
            return result;
        }
    }
}
