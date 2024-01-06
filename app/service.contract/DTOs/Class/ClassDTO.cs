using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Teacher;

namespace service.contract.DTOs.Class
{
    public class ClassDTO : AppEntityDefaultKeyDTO
    {
        public ClassDTO()
        {
            FeeDetails = new HashSet<FeeDetailDTO>();
        }
        public string ClassCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TeacherId { get; set; }
        public virtual TeacherDTO Teacher { get; set; } = null!;
        public virtual ICollection<FeeDetailDTO> FeeDetails { get; set; }
    }
}
