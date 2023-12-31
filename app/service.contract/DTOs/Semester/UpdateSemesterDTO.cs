using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Semester
{
    public class UpdateSemesterDTO : AppEntityDefaultKey
    {
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;

        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }

        public Guid? PrevSemesterId { get; set; }
    }
}
