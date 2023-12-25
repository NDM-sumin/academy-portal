using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Score
{
    public class UpdateScoreDTO : AppEntityDefaultKey
    {
        public double Value { get; set; }
        public Guid SubjectComponentID { get; set; }
        public Guid StudentId { get; set; }
    }
}
