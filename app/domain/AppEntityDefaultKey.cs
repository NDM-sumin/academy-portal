
namespace domain
{
    public class AppEntityDefaultKey : AppEntityAbstractKey<Guid>
    {
        public AppEntityDefaultKey()
        {
            Id = Guid.NewGuid();
        }

    }
}
