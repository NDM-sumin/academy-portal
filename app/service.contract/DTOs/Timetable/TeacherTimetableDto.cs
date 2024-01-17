﻿using service.contract.DTOs.Class;
using service.contract.DTOs.Room;
using service.contract.DTOs.SlotTimeTableAtWeek;
using service.contract.DTOs.Subject;

namespace service.contract.DTOs.Timetable
{
    public class TeacherTimetableDto
    {
        public SubjectDTO Subject { get; set; } = null!;
        public ClassDTO Class { get; set; } = null!;
        public RoomDTO? Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<AtWeekDto> AtWeek { get; set; } = new List<AtWeekDto>();
    }
}
