namespace domain.Base
{
    public class AppEntityDefaultKey : AppEntityAbstractKey<Guid>
    {
        public AppEntityDefaultKey()
        {
            Id = Guid.NewGuid();
        }

    }
}
