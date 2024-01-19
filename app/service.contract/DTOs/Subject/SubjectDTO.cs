﻿using domain;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.MajorSubject;

namespace service.contract.DTOs.Subject
{
    public class SubjectDTO : AppEntityDefaultKeyDTO
    {
        public SubjectDTO () {
            MajorSubjects = new HashSet<MajorSubjectDto>();
        }
        public string SubjectCode { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public decimal Price { get; set; }
        public ICollection<MajorSubjectDto> MajorSubjects { get; set; }

    }
}
