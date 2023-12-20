using domain.shared.Exceptions;
using domain.shared.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Base
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        [Route("/error")]
        public async Task<IActionResult> HandleError()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            System.IO.File.AppendAllTextAsync(ErrorConstants.ERROR_LOG_PATH, exceptionHandlerFeature.Error.ToString());

            var response = await Task.Run(() => SpecifyExceptionResult(exceptionHandlerFeature.Error));
            return response;
        }
        ObjectResult SpecifyExceptionResult(Exception exception)
        {

            object responseObject = new { code = 500, message = ErrorConstants.DEFAULT_ERROR_MSG };
            if (exception is AppException appException)
            {
                responseObject = new { code = appException.Code, message = appException.Message };
            };
            switch (exception)
            {
                case ForbidenException:
                    {
                        return StatusCode(403, responseObject);
                    }
                case ClientException:
                    {
                        return BadRequest(responseObject);
                    }
                case UnauthorizeException:
                    {
                        return Unauthorized(responseObject);
                    }
                case ServerException:
                default:
                    {
                        return StatusCode(500, responseObject);
                    }
            }

        }
    }
}
