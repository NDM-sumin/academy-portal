
using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class SubjectComponentRepository : AppGenericDefaultKeyRepository<SubjectComponent>, ISubjectComponentRepository
    {
        public SubjectComponentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task CreateDefaultSubjectComponent(Guid subjectId)
        {
            List<SubjectComponent> subjectComponents = new List<SubjectComponent>(){
                new SubjectComponent() {
                    SubjectID = subjectId,
                    Name = "Kiểm tra 1",
                    Weight = 0.15,
                    CreatedAt = DateTime.Now

                },
                new SubjectComponent() {
                    SubjectID = subjectId,
                    Name = "Kiểm tra 2",
                    Weight = 0.15,
                    CreatedAt = DateTime.Now.AddMinutes(15)
                },
                 new SubjectComponent() {
                    SubjectID = subjectId,
                    Name = "Thi cuối kì",
                    Weight = 0.7,
                    CreatedAt = DateTime.Now.AddMinutes(30)

                }
            };
            await this.AddRange(subjectComponents);
        }
    }
}