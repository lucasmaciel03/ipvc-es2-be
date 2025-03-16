using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO._shared;
using FreelanceManagerAPI.IO.Tarefas;
using FreelanceManagerAPI.Services.Tarefas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        readonly ITarefasService _tarefasService;

        public TarefasController(ITarefasService tarefasService)
        {
            _tarefasService = tarefasService;
        }

        // GET: api/Tarefas
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync() => Ok(await _tarefasService.GetAllAsync());

        // GET: api/Tarefas/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id) => Ok(await _tarefasService.GetByIdAsync(id));

        [HttpPost()]
        [Route("Create")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> CreateAsync([FromBody] TarefaModel model) => Ok(await _tarefasService.CreateAsync(model));

        //PUT: api/Tarefas/id
        [HttpPut("{id}")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] TarefaModel model) => Ok(await _tarefasService.UpdateAsync(id, model));

        //DELETE: api/Tarefas/Delete/:id
        [HttpDelete("{id}")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (await _tarefasService.CanDeleteAsync(id) is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto() { Message = "cantdelete" });

            await _tarefasService.DeleteAsync(id);
            return Ok();
        }

        //GET: api/Tarefas/NextCode
        [HttpGet("NextCode")]
        public async Task<ActionResult> GetNextCodeAsync() => Ok(await _tarefasService.GetNextCodeAsync());
    }
}