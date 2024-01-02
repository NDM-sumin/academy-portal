﻿namespace service.contract.DTOs.Class
{
    public class CreateClassDTO : AppEntityDefaultKeyDTO
    {
        public string ClassCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TeacherId { get; set; }
    }
}
