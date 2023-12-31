using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Teacher : Account
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
            Role = shared.Enums.Role.Teacher;
        }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
