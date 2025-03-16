using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO._shared;
using FreelanceManagerAPI.IO.Projects;
using FreelanceManagerAPI.Services.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService tarefasService)
        {
            _projectsService = tarefasService;
        }

        // GET: api/Projects
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync() => Ok(await _projectsService.GetAllAsync());

        // GET: api/Projects/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id) => Ok(await _projectsService.GetByIdAsync(id));

        [HttpPost()]
        [Route("Create")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> CreateAsync([FromBody] ProjectModel model) => Ok(await _projectsService.CreateAsync(model));

        //PUT: api/Projects/id
        [HttpPut("{id}")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] ProjectModel model) => Ok(await _projectsService.UpdateAsync(id, model));

        //DELETE: api/Projects/Delete/:id
        [HttpDelete("{id}")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (await _projectsService.CanDeleteAsync(id) is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto() { Message = "cantdelete" });

            await _projectsService.DeleteAsync(id);
            return Ok();
        }

        //GET: api/Projects/NextCode
        [HttpGet("NextCode")]
        public async Task<ActionResult> GetNextCodeAsync() => Ok(await _projectsService.GetNextCodeAsync());

        #region ProjectUsers

        //GET: api/Projects/User/:id
        [HttpGet("User/{id}")]
        public async Task<ActionResult> GetProjectUserByIdAsync(Guid id) => Ok(await _projectsService.GetProjectUserByIdAsync(id));

        //GET: api/Projects/User/Create
        [HttpPost()]
        [Route("User/Create")]
        public async Task<ActionResult> CreateProjectUserAsync([FromBody] ProjectUserModel model) => Ok(await _projectsService.CreateProjectUserAsync(model));
        #endregion

        #region Tarefas
        //GET: api/Project/:id/Tarefas
        [HttpGet("{id}/Tarefas")]
        public async Task<ActionResult> GetTarefasAsync(Guid id) => Ok(await _projectsService.GetTarefasAsync(id));

        #endregion
    }
}