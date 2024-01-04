using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Room
{
    public class RoomDTO
    {
        public string RoomCode { get; set; } = null!;
        public int Capacity { get; set; }
    }
}
