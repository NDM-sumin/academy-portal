using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Score
{
    public class TakeScore
    {
        public Guid ClassId { get; set; }
        public Guid StudentId { get; set; }
        public List<ScoreValue> Scores { get; set; } = new List<ScoreValue>();
    }
}
