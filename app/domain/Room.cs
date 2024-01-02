namespace domain
{
    public class Room : AppEntityDefaultKey
    {
        public Room()
        {
            RoomAttendances = new HashSet<Attendance>();
        }
        public string RoomCode { get; set; } = null!;
        public int Capacity { get; set; }
        public virtual ICollection<Attendance> RoomAttendances { get; set; }
    }
}
