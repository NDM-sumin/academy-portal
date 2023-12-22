using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Teacher : AppEntityDefaultKey
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }
        public Guid AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Class> Classes { get; set; }
    }
}
