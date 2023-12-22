using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Class : AppEntityDefaultKey
    {
        public Class()
        {
            FeeDetails = new HashSet<FeeDetail>();
        }
        public string ClassCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<FeeDetail> FeeDetails { get; set; }
    }
}
