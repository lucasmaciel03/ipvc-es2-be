using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceManagerAPI.IO.Constants
{
    public class AppConstantsDto
    {
        public string ApplicationUserId { get; set; }
        public string ApplicationUserName { get; set; }
        public string ApplicationUserFullName { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}