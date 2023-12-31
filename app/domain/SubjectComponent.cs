using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class SubjectComponent : AppEntityDefaultKey
    {
        public SubjectComponent()
        {
            Scores = new HashSet<Score>();
        }
        public string Name { get; set; } = null!;
        public double Weight { get; set; }
        public Guid SubjectID { get; set; }
        [ForeignKey(nameof(SubjectID))]
        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<Score> Scores { get; set; }
    }
}
