namespace service.contract.DTOs.Score
{
    public class CreateScoreDTO : AppEntityDefaultKeyDTO
    {
        public double Value { get; set; }
        public Guid SubjectComponentID { get; set; }
        public Guid StudentId { get; set; }
    }
}
