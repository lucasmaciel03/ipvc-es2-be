using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO._shared;
using FreelanceManagerAPI.IO.Clients;
using FreelanceManagerAPI.Services.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        // GET: api/Clients
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync() => Ok(await _clientsService.GetAllAsync());

        // GET: api/Clients/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id) => Ok(await _clientsService.GetByIdAsync(id));

        [HttpPost()]
        [Route("Create")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> CreateAsync([FromBody] ClientModel model) => Ok(await _clientsService.CreateAsync(model));

        //PUT: api/Clients/id
        [HttpPut("{id}")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] ClientModel model) => Ok(await _clientsService.UpdateAsync(id, model));

        //DELETE: api/Clients/Delete/:id
        [HttpDelete("{id}")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (await _clientsService.CanDeleteAsync(id) is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto() { Message = "cantdelete" });

            await _clientsService.DeleteAsync(id);
            return Ok();
        }

        //GET: api/Clients/NextCode
        [HttpGet("NextCode")]
        public async Task<ActionResult> GetNextCodeAsync() => Ok(await _clientsService.GetNextCodeAsync());
    }
}