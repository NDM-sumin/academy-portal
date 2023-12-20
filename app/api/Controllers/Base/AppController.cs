using api.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Security.Claims;

namespace api.Controllers.Base
{
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AppActionFilter]
    [Route("api/[controller]")]
    public abstract class AppController : ODataController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public Guid GetUserId()
        {
            var user = this.User;
            return Guid.Parse(user.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value);
        }
    }
}
