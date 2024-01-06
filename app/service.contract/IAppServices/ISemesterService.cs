﻿using domain;
using service.contract.DTOs.Semester;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface ISemesterService : IAppCRUDDefaultKeyService<SemesterDTO, CreateSemesterDTO, UpdateSemesterDTO, Semester>
    {
        SemesterDTO GetCurrentSemester(Guid studentId);
    }
}
