using service.contract.DTOs.FeeDetail;

namespace service.contract.DTOs.Subject
{
    public class SubjectDTO : AppEntityDefaultKeyDTO
    {
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public decimal Price { get; set; }
        public virtual ICollection<FeeDetailDTO> FeeDetails { get; set; }
      
    }
}
