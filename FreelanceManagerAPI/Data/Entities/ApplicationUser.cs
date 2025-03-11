using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.IO.ApplicationUsers;
using Microsoft.AspNetCore.Identity;

namespace FreelanceManagerAPI.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public ApplicationUser(ApplicationUserModel model)
        {
            Email = model.Email;
            UserName = model.UserName;
            FullName = model.FullName;
            PhoneNumber = model.PhoneNumber;
            SecurityStamp = Guid.NewGuid().ToString();
            LockoutEnabled = false;
            EmailConfirmed = true;
            CreatedAt = DateTime.Now;
        }

        public string FullName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}