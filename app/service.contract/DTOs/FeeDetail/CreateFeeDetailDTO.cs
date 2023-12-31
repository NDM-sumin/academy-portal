﻿using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs.FeeDetail
{
    public class CreateFeeDetailDTO : AppEntityDefaultKey
    {
        public Guid? ClassId { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid SemesterId { get; set; }
    }
}