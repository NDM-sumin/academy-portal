﻿namespace service.contract.DTOs.Score
{
    public class ScoreDTO : AppEntityDefaultKeyDTO
    {
        public double Value { get; set; }
        public Guid SubjectComponentID { get; set; }
        public Guid StudentId { get; set; }
    }
}
