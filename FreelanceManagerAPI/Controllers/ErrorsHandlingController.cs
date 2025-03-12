using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO._shared;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManagerAPI.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsHandlingController : ControllerBase
    {
        // readonly ILogsService _logsService;

        // public ErrorsHandlingController(ILogsService logsService)
        // {
        //     _logsService = logsService;
        // }

        [Route("/error-handling")]
        public async Task<IActionResult> HandleErrorDev()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            // var log = new Log
            // {
            //     LogType = LogType.Exception,
            //     Feature = exceptionHandlerFeature.Error.Source ?? "GLOBAL",
            //     Message = exceptionHandlerFeature.Error.Message,
            //     Path = exceptionHandlerFeature.Path
            // };

            // await _logsService.LogExcecption(exceptionHandlerFeature);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto(exceptionHandlerFeature.Error));
        }
    }
}