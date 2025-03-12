using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.IO.Constants;
using FreelanceManagerAPI.Services.AppConstants;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppConstantsController : ControllerBase
    {
        readonly IAppConstantsService _appConstantsService;
        readonly IHttpContextAccessor _httpAccessor;

        public AppConstantsController(IAppConstantsService appConstantsService, IHttpContextAccessor httpAccessor)
        {
            _appConstantsService = appConstantsService;
            _httpAccessor = httpAccessor;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(AppConstantsDto), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAppConstantsAsync()
        {
            string userId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "id")?.Value!;
            if (string.IsNullOrEmpty(userId))
                return Ok();

            return Ok(await _appConstantsService.GetAppConstantsAsync(userId));
        }
    }
}