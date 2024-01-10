using service.contract.DTOs.SubjectComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Score
{
    public class StudentScoreDTO
    {
        public string StudentName { get; set; }
        public List<SubjectComponentDTO> SubjectComponents { get; set; }
    }
}
