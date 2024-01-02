namespace service.contract.DTOs.Class
{
    public class ClassDTO : AppEntityDefaultKeyDTO
    {
        public string ClassCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TeacherId { get; set; }
    }
}
