﻿using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Semester
{
    public class CreateSemesterDTO: AppEntityDefaultKey
    {
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
