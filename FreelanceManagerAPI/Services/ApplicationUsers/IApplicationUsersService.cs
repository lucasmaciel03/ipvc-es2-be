using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.IO.ApplicationUsers;

namespace FreelanceManagerAPI.Services.ApplicationUsers
{
    public interface IApplicationUsersService
    {
        Task<List<ApplicationUserDto>> GetAllAsync();
        Task<ApplicationUserDto> GetByIdAsync(string id);
        Task<ApplicationUserDto> CreateAsync(ApplicationUserModel model);
        Task<ApplicationUserDto> UpdateAsync(ApplicationUserModel model);
        Task DeleteAsync(string userId);
    }
}