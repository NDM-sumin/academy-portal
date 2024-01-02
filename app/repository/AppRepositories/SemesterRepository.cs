﻿using domain;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.AppRepositories
{
    public class SemesterRepository : AppGenericDefaultKeyRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AppDbContext context) : base(context)
        {
        }

        public Semester getCurrentSemester(Guid studentId)
        {
            return Context.StudentSemesters.Include(ss => ss.Semester).FirstOrDefault(ss => ss.IsNow == true && ss.StudentId.Equals(studentId)).Semester;
        }
    }
}
