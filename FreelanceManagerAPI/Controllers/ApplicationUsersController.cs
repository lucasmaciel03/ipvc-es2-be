using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.IO._shared;
using FreelanceManagerAPI.IO.ApplicationUsers;
using FreelanceManagerAPI.Services.ApplicationUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        readonly IApplicationUsersService _applicationUsersService;
        readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUsersController(IApplicationUsersService applicationUsersService, UserManager<ApplicationUser> userManager)
        {
            _applicationUsersService = applicationUsersService;
            _userManager = userManager;
        }

        // POST: api/ApplicationUsers
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync() => Ok(await _applicationUsersService.GetAllAsync());

        // GET: api/ApplicationUsers/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id) => Ok(await _applicationUsersService.GetByIdAsync(id));

        // POST: api/ApplicationUsers/Create
        [HttpPost()]
        [Route("Create")]
        public async Task<ActionResult> CreateAsync([FromBody] ApplicationUserModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists is not null && userExists.IsDeleted is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto { Message = "userexists" });

            return Ok(await _applicationUsersService.CreateAsync(model));
        }

        //PUT: api/ApplicationUsers/:id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(string id, [FromBody] ApplicationUserModel model) => Ok(await _applicationUsersService.UpdateAsync(model));

        //DELETE: api/ApplicationUsers/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            await _applicationUsersService.DeleteAsync(id);
            return Ok();
        }
    }
}