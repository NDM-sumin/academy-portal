namespace service.contract.DTOs.FeeDetail
{
    public class CreateFeeDetailDTO : AppEntityDefaultKeyDTO
    {
        public Guid? PaymentTransactionId{get;set;}
        public Guid? ClassId { get; set; }
        public Guid StudentSemesterId { get; set; }
        public Guid SubjectId { get; set; }
        public float Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}
