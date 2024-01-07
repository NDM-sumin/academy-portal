﻿using api.Controllers.Base;
using domain;
using service.contract.DTOs.Class;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class ClassController : AppCRUDDefaultKeyController<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>
    {


        public ClassController(IClassService appCRUDService) : base(appCRUDService)
        {

        }


    }
}
