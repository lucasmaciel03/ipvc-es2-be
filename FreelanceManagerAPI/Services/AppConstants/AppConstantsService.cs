using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.IO.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FreelanceManagerAPI.Services.AppConstants
{
    public class AppConstantsService : IAppConstantsService
    {
        readonly UserManager<ApplicationUser> _userManager;

        public AppConstantsService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppConstantsDto> GetAppConstantsAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(entity => entity.Id == userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            return new AppConstantsDto() { ApplicationUserId = user.Id, ApplicationUserName = user.UserName, ApplicationUserFullName = user.FullName, Roles = userRoles.ToList() };
        }
    }
}
