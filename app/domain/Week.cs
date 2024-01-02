namespace domain
{
    public class Week : AppEntityDefaultKey
    {
        public Week()
        {
            SlotTimeTableAtWeeks = new HashSet<SlotTimeTableAtWeek>();
        }
        public int WeekName { get; set; }
        public virtual ICollection<SlotTimeTableAtWeek> SlotTimeTableAtWeeks { get; set; }
    }
}
