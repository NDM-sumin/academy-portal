using service.contract.DTOs.Score;
using service.contract.DTOs.Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.SubjectComponent
{
    public class SubjectComponentDTO : AppEntityDefaultKeyDTO
    {
        public SubjectComponentDTO()
        {
            Scores = new HashSet<ScoreDTO>();
        }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Weight { get; set; }
        public string? Comment { get; set; }
        public Guid SubjectID { get; set; }
        [ForeignKey(nameof(SubjectID))]
        public virtual SubjectDTO Subject { get; set; } = null!;
        public virtual ICollection<ScoreDTO> Scores { get; set; }
    }
}
