using service.contract.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Class
{
    public class ClassInformation
    {
        public string ClassCode { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }
}
