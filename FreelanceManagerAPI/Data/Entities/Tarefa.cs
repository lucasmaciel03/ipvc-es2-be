using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities.Base;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO.Tarefas;

namespace FreelanceManagerAPI.Data.Entities
{
    public class Tarefa : EntityBase
    {
        public Tarefa() { }
        public Tarefa(TarefaModel model, int number)
        {
            Code = model.Code;
            Name = model.Name;
            Description = model.Description;
            Notes = model.Notes;
            InternalNumber = number;

        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public hourly_rate
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TarefaStatus Status { get; set; } = TarefaStatus.Created;
        public string Notes { get; set; }
        public int InternalNumber { get; set; }
        public string ApplicationUserId { get; set; }
        public string? AssociatedUserId { get; set; }
        public Guid? ProjectId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Project Project { get; set; }
    }
}