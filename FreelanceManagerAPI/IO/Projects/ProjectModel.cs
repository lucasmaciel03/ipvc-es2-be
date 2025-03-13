using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Enum;

namespace FreelanceManagerAPI.IO.Projects
{
    public class ProjectModel
    {
        public Guid? Id { get; set; }
        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        public Guid ClientId { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Created;
        [Required, MaxLength(100)]
        public string Notes { get; set; }
        public bool IsActive { get; set; }

    }
}