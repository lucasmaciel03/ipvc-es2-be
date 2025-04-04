using FreelanceManagerAPI.Data.Entities.Base;
using FreelanceManagerAPI.IO.Tarefas;

namespace FreelanceManagerAPI.Data.Entities;

public class Timesheet : EntityBase
{
    public Timesheet(){}

    public Timesheet(TimesheetModel model, int number)
    {
        TarefaId = model.TarefaId;
        Notes = model.Notes;
        Hours = model.Hours;
        InternalNumber = number;
        Date = model.Date ?? DateTime.Now; // Set to current date if null
    }

    public Guid TarefaId { get; set; }
    public string Notes { get; set; }
    public string Hours { get; set; }  
    public int InternalNumber { get; set; }
    public DateTime? Date { get; set; } 
    public Tarefa Tarefa { get; set; }
}