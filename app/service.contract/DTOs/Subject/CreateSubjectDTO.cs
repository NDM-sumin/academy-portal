namespace service.contract.DTOs.Subject
{
    public class CreateSubjectDTO: AppEntityDefaultKeyDTO
    {
        public CreateSubjectDTO()
        {
            MajorIds = new List<Guid>();
        }
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public List<Guid> MajorIds { get; set; }
        public Guid SemesterId { get; set; }
    }
}
