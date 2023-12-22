using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Attendance : AppEntity
    {
        public Guid RoomId { get; set; }
        public Guid SlotTimeTableAtWeekId { get; set; }
        public Guid FeeDetailId { get; set; }


        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; } = null!;


        [ForeignKey(nameof(SlotTimeTableAtWeekId))]
        public virtual SlotTimeTableAtWeek SlotTimeTableAtWeek { get; set; } = null!;


        [ForeignKey(nameof(FeeDetailId))]
        public virtual FeeDetail FeeDetail { get; set; } = null!;
    }
}
