using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO._shared;

namespace FreelanceManagerAPI.IO.Tarefas
{
    public class TarefaDto : BaseDto<Tarefa>
    {
        public TarefaDto() { }
        public TarefaDto(Tarefa entity) : base(entity)
        {
            Id = entity.Id;
            Code = entity.Code;
            Name = entity.Name;
            Description = entity.Description;
            Notes = entity.Notes;
            StartDate = entity.StartDate;
            EndDate = entity.EndDate;
            Status = entity.Status;

        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? ApplicationUserId { get; set; }
        public TarefaStatus Status { get; set; } = TarefaStatus.Created;

    }
}