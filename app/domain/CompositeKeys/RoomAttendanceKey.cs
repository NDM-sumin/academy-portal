namespace domain.CompositeKeys
{
    public class RoomAttendanceKey
    {
        public Guid AttendanceId { get; set; }
        public Guid RoomId { get; set; }
        public Guid ClassId { get; set; }
    }
}
