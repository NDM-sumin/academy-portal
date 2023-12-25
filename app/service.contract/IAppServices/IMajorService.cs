﻿using domain;
using service.contract.DTOs.Account;
using service.contract.DTOs.Major;
using service.contract.DTOs.Subject;
using service.contract.IAppServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public interface IMajorService : IAppCRUDDefaultKeyService<MajorDTO, CreateMajorDTO, UpdateMajorDTO, Major>
    {
        Task<SubjectDTO> GetSubjectByMajor(Guid majorId);
    }
}
