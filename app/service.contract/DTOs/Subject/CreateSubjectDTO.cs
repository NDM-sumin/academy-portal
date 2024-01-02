namespace service.contract.DTOs.Subject
{
    public class CreateSubjectDTO: AppEntityDefaultKeyDTO
    {
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
    }
}
