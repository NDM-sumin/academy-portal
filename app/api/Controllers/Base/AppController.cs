using api.Attributes;
using domain.shared.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Security.Claims;

namespace api.Controllers.Base
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AppActionFilter]
    [Route("api/[controller]")]
    public abstract class AppController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public Guid GetUserId()
        {
            var user = this.User;
            return Guid.Parse(user.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value ?? throw new UnauthorizeException());
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetIpAddress()
        {
            string ipAddress = string.Empty;
            try
            {
                ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR");

                if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() == "unknown") || ipAddress.Length > 45)
                    ipAddress = HttpContext.GetServerVariable("REMOTE_ADDR");
            }
            catch
            {
            }

            return ipAddress ?? "::1";
        }
    }
}
