using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Student : AppEntityDefaultKey
    {
        public Student()
        {
            FeeDetails = new HashSet<FeeDetail>();
        }
        public string StudentCode { get; set; } = null!;
        public Guid AccountId { get; set; }
        public Guid MajorId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey(nameof(MajorId))]
        public virtual Major Major { get; set; } = null!;
        public virtual ICollection<FeeDetail> FeeDetails { get; set; }
    }
}
