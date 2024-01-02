namespace service.contract.DTOs.FeeDetail
{
    public class FeeDetailDTO : AppEntityDefaultKeyDTO
    {
        public float Amount { get; set; }
        public string? Content { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PayDate { get; set; }
        public Guid? ClassId { get; set; }
        public Guid StudentSemesterId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
