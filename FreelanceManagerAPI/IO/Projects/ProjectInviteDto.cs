using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Enum;
using FreelanceManagerAPI.IO._shared;

namespace FreelanceManagerAPI.IO.Projects
{
    public class ProjectInviteDto : BaseDto<ProjectInvite>
    {
        public ProjectInviteDto() { }
        public ProjectInviteDto(ProjectInvite entity)
        {
            Id = entity.Id;
            ProjectId = entity.ProjectId;
            InvitedApplicationUserId = entity.InvitedApplicationUserId;
            SenderApplicationUserId = entity.SenderApplicationUserId;
            Status = entity.Status;
            InvitedAt = entity.InvitedAt;
            Description = entity.Description;

        }
        public Guid ProjectId { get; set; }
        public string InvitedApplicationUserId { get; set; }
        public string SenderApplicationUserId { get; set; }
        public string Description { get; set; }
        public DateTime InvitedAt { get; set; }
        public ProjectInviteStatus Status { get; set; }


    }
}