﻿using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.Major
{
    public class CreateMajorDTO : AppEntityDefaultKey
    {
        public string MajorCode { get; set; } = null!;
        public string MajorName { get; set; } = null!;
    }
}
