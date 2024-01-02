namespace domain
{
    public class Slot : AppEntityDefaultKey
    {
        public Slot()
        {
            SlotTimeTableAtWeeks = new HashSet<SlotTimeTableAtWeek>();
        }
        public DateTime StartTime {  get; set; }
        public DateTime EndTime { get; set; }
        public string SlotName { get; set; } = null!;
        public virtual ICollection<SlotTimeTableAtWeek> SlotTimeTableAtWeeks { get; set; }
    }
}
