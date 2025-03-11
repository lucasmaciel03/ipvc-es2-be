using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.IO.Authentication;
using FreelanceManagerAPI.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignInAsync([FromBody] SignInModel model)
        {
            AuthenticationDto authenticationDto = await _authenticationService.SignInAsync(model);

            if (authenticationDto is null)
                return Unauthorized();

            return Ok(authenticationDto);
        }

    }
}