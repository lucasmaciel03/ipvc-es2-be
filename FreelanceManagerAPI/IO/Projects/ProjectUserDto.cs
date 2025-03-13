using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO._shared;

namespace FreelanceManagerAPI.IO.Projects
{
    public class ProjectUserDto : BaseDto<ProjectUser>
    {
        public ProjectUserDto()
        {

        }
        public ProjectUserDto(ProjectUser entity)
        {
            Id = entity.Id;
            ProjectId = entity.ProjectId;
            ApplicationUserId = entity.ApplicationUserId;
            Role = entity.Role;
            JoinedAt = entity.JoinedAt;
            RemovedAt = entity.RemovedAt;
            Notes = entity.Notes;

        }
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserType Role { get; set; } = ApplicationUserType.Normal;

        public DateTime? JoinedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
        public string Notes { get; set; }

    }
}