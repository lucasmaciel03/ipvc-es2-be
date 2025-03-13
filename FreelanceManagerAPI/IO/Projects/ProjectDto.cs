using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO._shared;

namespace FreelanceManagerAPI.IO.Projects
{
    public class ProjectDto : BaseDto<Project>
    {
        public ProjectDto()
        {

        }
        public ProjectDto(Project entity) : base(entity)
        {
            Id = entity.Id;
            Code = entity.Code;
            Name = entity.Name;
            Description = entity.Description;
            Notes = entity.Notes;
            Status = entity.Status;
            ClientId = entity.ClientId;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Created;
        public Guid ClientId { get; set; }


    }
}