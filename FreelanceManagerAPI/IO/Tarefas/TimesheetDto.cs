using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.IO._shared;


namespace FreelanceManagerAPI.IO.Tarefas
{
    public class TimesheetDto : BaseDto<Timesheet>
    {
        public TimesheetDto()
        {
            Hours = string.Empty;
            Notes = string.Empty;
        }

        public TimesheetDto(Timesheet entity) : base(entity)
        {
            Id = entity.Id;
            Date = entity.Date ?? DateTime.Now;
            Hours = entity.Hours;
            Notes = entity.Notes;
            
        }

        public DateTime Date { get; set; }
        public string Hours { get; set; }
        public string Notes { get; set; }
        public Guid TarefaId { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}