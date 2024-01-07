﻿using api.Controllers.Base;
using domain;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Subject;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class SemesterController : AppCRUDDefaultKeyWithOdataController<SemesterDTO, CreateSemesterDTO, UpdateSemesterDTO, Semester>
    {


        public SemesterController(ISemesterService appCRUDService) : base(appCRUDService)
        {

        }

        [HttpGet("GetSemesterByStudent")]
        public async Task<List<Semester>> GetSemesterByStudent(Guid studentId)
        {
            return (appCRUDService as ISemesterService).GetSemesterByStudent(studentId);
        }
    }
}
