using service.contract.DTOs.Attendance;
using service.contract.DTOs.Class;
using service.contract.DTOs.StudentSemester;
using service.contract.DTOs.Subject;
using service.contract.DTOs.VNPay;

namespace service.contract.DTOs.FeeDetail
{
    public class FeeDetailDTO : AppEntityDefaultKeyDTO
    {
        public FeeDetailDTO()
        {
            Attendances = new HashSet<AttendanceDTO>();
        }
        public float Amount { get; set; }
        public string? Content { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PayDate { get; set; }
        public Guid? ClassId { get; set; }
        public Guid StudentSemesterId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid PaymentTransactionId{get;set;}
        public virtual ClassDTO? Class { get; set; }
        public virtual SubjectDTO Subject { get; set; } = null!;

        public ICollection<AttendanceDTO> Attendances { get; set; }

        public virtual StudentSemesterDto StudentSemester { get; set; } = null!;

        public virtual PaymentTransactionDto PaymentTransaction { get; set; } = null!;
    }
}
