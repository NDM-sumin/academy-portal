using System.ComponentModel.DataAnnotations.Schema;

namespace domain
{
    public class SlotTimeTableAtWeek : AppEntityDefaultKey
    {
        public SlotTimeTableAtWeek()
        {
            Attendances = new HashSet<Attendance>();
        }
        public Guid SlotId { get; set; }
        public Guid TimetableId { get; set; }

        public Guid WeekId { get; set; }
        public bool IsAttendance { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
        public Guid FeeDetailId { get; set; }

        [ForeignKey(nameof(SlotId))]
        public virtual Slot Slot { get; set; } = null!;

        [ForeignKey(nameof(WeekId))]
        public virtual Week Week { get; set; } = null!;

        [ForeignKey(nameof(TimetableId))]
        public virtual Timetable Timetable { get; set; } = null!;

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
