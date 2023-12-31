using api.Controllers.Base;
using domain;
using domain.shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using service.AppServices;
using service.contract.DTOs;
using service.contract.DTOs.Account;
using service.contract.DTOs.Class;
using service.contract.IAppServices;
using System.Security.Principal;

namespace api.Controllers
{
    public class ClassController : AppCRUDDefaultKeyWithOdataController<ClassDTO, CreateClassDTO, UpdateClassDTO, Class>
    {


        public ClassController(IClassService appCRUDService) : base(appCRUDService)
        {

        }


    }
}
