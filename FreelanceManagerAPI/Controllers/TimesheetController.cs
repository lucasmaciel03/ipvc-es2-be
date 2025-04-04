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
    public class TimesheetController : ControllerBase
    {
        readonly ITimesheetService _timesheetService;

        public TimesheetController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }
        //Get api/Timesheet
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync() => Ok(await _timesheetService.GetAllAsync());
        
        //Get api/Timesheet/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id) => Ok(await _timesheetService.GetByIdAsync(id));

        //Post api/Timesheet/Create
        [HttpPost()]
        [Route("Create")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> CreateAsync([FromBody] TimesheetModel model) => Ok(await _timesheetService.CreateAsync(model));

        //Put api/Timesheet/:id
        [HttpPut("{id}")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] TimesheetModel model) => Ok(await _timesheetService.UpdateAsync(id, model));

        //Delete api/Timesheet/:id
        [HttpDelete("{id}")]
        [Authorize(Roles = ApplicationUserRoles.Admin)]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (await _timesheetService.CanDeleteAsync(id) is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto() { Message = "cantdelete" });

            await _timesheetService.DeleteAsync(id);
            return Ok();
        }

        
    }
}