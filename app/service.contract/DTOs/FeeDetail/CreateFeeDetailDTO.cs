namespace service.contract.DTOs.FeeDetail
{
    public class CreateFeeDetailDTO : AppEntityDefaultKeyDTO
    {
        public Guid? ClassId { get; set; }
        public Guid StudentSemesterId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
