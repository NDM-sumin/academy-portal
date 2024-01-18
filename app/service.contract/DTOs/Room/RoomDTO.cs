using service.contract.DTOs.Attendance;

namespace service.contract.DTOs.Room
{
    public class RoomDTO : AppEntityDefaultKeyDTO
    {
        public RoomDTO()
        {
        }
        public string RoomCode { get; set; } = null!;
        public int Capacity { get; set; }

    }
}
