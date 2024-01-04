namespace domain
{
    public class Slot : AppEntityDefaultKey
    {
        public Slot()
        {
            SlotTimeTableAtWeeks = new HashSet<SlotTimeTableAtWeek>();
        }
        public string StartTime {  get; set; }
        public string EndTime { get; set; }
        public string SlotName { get; set; } = null!;
        public virtual ICollection<SlotTimeTableAtWeek> SlotTimeTableAtWeeks { get; set; }
    }
}
