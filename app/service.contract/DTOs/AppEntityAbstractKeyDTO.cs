namespace service.contract.DTOs
{
    public class AppEntityAbstractKeyDTO<TKey> : AppEntityDTO
        where TKey : struct
    {
        public TKey Id { get; set; }

    }
}
