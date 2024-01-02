namespace service.contract.DTOs.Subject
{
    public class SubjectDTO : AppEntityDefaultKeyDTO
    {
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
    }
}
