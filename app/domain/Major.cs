using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Major : AppEntityDefaultKey
    {
        public Major()
        {
            MajorSubjects = new HashSet<MajorSubject>();
            Students = new HashSet<Student>();  
        }
        public string MajorCode { get; set; } = null!;
        public string MajorName { get; set; } = null!;
        public virtual ICollection<MajorSubject> MajorSubjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
