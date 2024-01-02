using domain;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class ScoreRepository : AppGenericDefaultKeyRepository<Score>, IScoreRepository
    {
        public ScoreRepository(AppDbContext context) : base(context)
        {
        }

        public List<Subject> getOweSubject(Guid studentId)
        {
            return Context.Subjects
                    .Select(subject => new
                    {
                        Subject = subject,
                        TotalScore = subject.SubjectComponents
                            .Sum(component => component.Weight *
                                component.Scores.FirstOrDefault(score => score.StudentId == studentId).Value)
                    })
                    .Where(result => result.TotalScore < 5)
                    .Select(result => result.Subject)
                    .ToList();
        }
    }
}
