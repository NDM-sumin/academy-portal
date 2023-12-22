using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.CompositeKeys
{
    public class MajorSubjectKey
    {
        public Guid MajorId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
