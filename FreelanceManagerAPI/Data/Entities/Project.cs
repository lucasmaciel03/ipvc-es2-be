using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities.Base;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO.Projects;

namespace FreelanceManagerAPI.Data.Entities
{
    public class Project : EntityBase
    {
        public Project() { }

        public Project(ProjectModel model, int number)
        {
            Code = model.Code;
            Name = model.Name;
            Description = model.Description;
            Notes = model.Notes;
            InternalNumber = number;
            Status = model.Status;
            ClientId = model.ClientId;
            ApplicationUserId = model.ApplicationUserId;

        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int InternalNumber { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Created;
        public string? ApplicationUserId { get; set; }
        public Guid? ClientId { get; set; }
        public Client Client { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Tarefa> Tarefas { get; set; }
        public List<ProjectUser> ProjectUsers { get; set; }
    }
}