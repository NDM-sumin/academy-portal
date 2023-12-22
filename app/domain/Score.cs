using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Score : AppEntityDefaultKey
    {
        public double Value { get; set; }
        public Guid SubjectComponentID { get; set; }
        [ForeignKey(nameof(SubjectComponentID))]
        public virtual SubjectComponent SubjectComponent { get; set; } = null!;
    }
}
