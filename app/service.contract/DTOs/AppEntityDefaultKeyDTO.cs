namespace service.contract.DTOs
{
    public class AppEntityDefaultKeyDTO : AppEntityAbstractKeyDTO<Guid>
    {
        public AppEntityDefaultKeyDTO()
        {
            Id = Guid.NewGuid();
        }

    }
}
