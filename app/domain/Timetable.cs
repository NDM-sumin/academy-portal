namespace domain
{
    public class Timetable : AppEntityDefaultKey
    {
        public Timetable()
        {
            SlotTimeTableAtWeeks = new HashSet<SlotTimeTableAtWeek>();
        }
        public string WeekDay { get; set; } = null!;
        public virtual ICollection<SlotTimeTableAtWeek> SlotTimeTableAtWeeks { get; set; }
    }
}
