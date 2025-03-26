using FreelanceManagerAPI.Data.Entities.Base;
using FreelanceManagerAPI.IO.Tarefas;

namespace FreelanceManagerAPI.Data.Entities;

public class Timesheet : EntityBase
{
    public Timesheet(){}

    public Timesheet(TimesheetModel model)
    {
        TarefaId = model.TarefaId;
        Notes = model.Notes;
        Hours = model.Hours;
        Date = model.Date ?? DateTime.Now; // Set to current date if null
    }

    public Guid TarefaId { get; set; }
    public string Notes { get; set; }
    public decimal Hours { get; set; }  
    public DateTime? Date { get; set; } 
    public Tarefa Tarefa { get; set; }
}