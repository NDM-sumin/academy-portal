namespace service.contract.DTOs.FeeDetail
{
    public class CreateFeeDetailDTO : AppEntityDefaultKeyDTO
    {
        public Guid? ClassId { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid SemesterId { get; set; }
    }
}
