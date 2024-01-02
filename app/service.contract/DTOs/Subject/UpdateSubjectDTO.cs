namespace service.contract.DTOs.Subject
{
    public class UpdateSubjectDTO : AppEntityDefaultKeyDTO
    {
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
    }
}
