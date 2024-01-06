using domain;
using service.contract.DTOs.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Timetable
{
    public class TimeTableDTO
    {
        public domain.Subject Subject { get; set; } = null!;
        public domain.Room? Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SlotTimeTableAtWeek> AtWeek { get; set; } = new List<SlotTimeTableAtWeek>();
    }
}
