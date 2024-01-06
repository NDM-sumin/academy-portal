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
        public int SlotName { get; set; }
        public virtual ICollection<SlotTimeTableAtWeek> SlotTimeTableAtWeeks { get; set; }
    }
}
