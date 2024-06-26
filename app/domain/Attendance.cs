﻿using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class Attendance : AppEntityDefaultKey
    {
        public Guid RoomId { get; set; }
        public Guid SlotTimeTableAtWeekId { get; set; }
        public Guid FeeDetailId { get; set; }
        public bool? IsAttendance { get; set; }
        public string? Note { get; set; }
        public DateTime? Date { get; set; }
        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; } = null!;


        [ForeignKey(nameof(SlotTimeTableAtWeekId))]
        public virtual SlotTimeTableAtWeek SlotTimeTableAtWeek { get; set; } = null!;


        [ForeignKey(nameof(FeeDetailId))]
        public virtual FeeDetail FeeDetail { get; set; } = null!;
    }
}
