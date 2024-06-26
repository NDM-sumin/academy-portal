﻿using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SemesterController : AppCRUDDefaultKeyController<SemesterDTO, CreateSemesterDTO, UpdateSemesterDTO, Semester>
    {
        readonly IStudentSemesterService studentSemesterService;
    


        public SemesterController(ISemesterService appCRUDService,
        IStudentSemesterService studentSemesterService
        
        ) : base(appCRUDService)
        {
this.studentSemesterService = studentSemesterService;
        }


        [HttpPost("SetNextSemester")]
        public async Task<IActionResult> SetNextSemester(){
            return Ok(await studentSemesterService.SetNextSemester());
        }

    }
}
