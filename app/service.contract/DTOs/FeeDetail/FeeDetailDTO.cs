using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.FeeDetail
{
    public class FeeDetailDTO : AppEntityDefaultKey
    {
        public float Amount { get; set; }
        public string? Content { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PayDate { get; set; }
        public Guid? ClassId { get; set; }
        public Guid StudentSemesterId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
