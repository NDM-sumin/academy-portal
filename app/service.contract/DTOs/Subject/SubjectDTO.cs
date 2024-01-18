using domain;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.MajorSubject;

namespace service.contract.DTOs.Subject
{
    public class SubjectDTO : AppEntityDefaultKeyDTO
    {
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public decimal Price { get; set; }

    }
}
