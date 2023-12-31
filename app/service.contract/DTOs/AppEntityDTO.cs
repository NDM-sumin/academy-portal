namespace service.contract.DTOs
{
    public class AppEntityDTO
    {

        public AppEntityDTO()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
