using FreelanceManagerAPI.Data.Entities.Base;

namespace FreelanceManagerAPI.Data.Entities;

public class TaskRegist : EntityBase
{
    public TaskRegist(){}
    public TaskRegist(TaskRegist model)
    {
        TarefaId = model.TarefaId;
        ApllicationUserId = model.ApllicationUserId;
        notes = model.notes;
        time = model.time;
        date = model.date;
    }
    
    
    public Guid TarefaId { get; set; }
    public string ApllicationUserId { get; set; }
    public string time { get; set; }
    public string notes { get; set; }
    public DateTime date { get; set; } = DateTime.Now;
    public Tarefa Tarefa { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}