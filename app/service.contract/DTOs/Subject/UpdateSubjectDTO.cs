namespace service.contract.DTOs.Subject
{
    public class UpdateSubjectDTO : AppEntityDefaultKeyDTO
    {
        public UpdateSubjectDTO()
        {
            MajorIds = new List<Guid>();
        }
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public decimal Price { get; set; }
        public List<Guid> MajorIds { get; set; }
        public Guid SemesterId { get; set; }
    }
}
