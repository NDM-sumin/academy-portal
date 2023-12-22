using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class MajorSubject : AppEntityDefaultKey
    {
        public MajorSubject()
        {
           
        }
        public Guid MajorId { get; set; }
        public Guid SubjectId { get; set; }
        [ForeignKey(nameof(MajorId))]
        public virtual Major Major { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

      
    }
}
