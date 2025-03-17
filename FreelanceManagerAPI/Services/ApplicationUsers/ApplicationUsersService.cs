using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.UnitOfWork;
using FreelanceManagerAPI.IO.ApplicationUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FreelanceManagerAPI.Services.ApplicationUsers
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUsersService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<List<ApplicationUserDto>> GetAllAsync()
        {
            var users = await _userManager.Users.Where(u => u.IsDeleted == false).ToListAsync();

            var result = new List<ApplicationUserDto>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                result.Add(new ApplicationUserDto(user, roles?.ToList()));
            }

            return result.ToList();
        }

        public async Task<ApplicationUserDto> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null || user.IsDeleted)
                return null;

            var roles = await _userManager.GetRolesAsync(user);
            return new ApplicationUserDto(user, roles?.ToList());
        }

        public async Task<ApplicationUserDto> CreateAsync(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser(model);
            await _userManager.CreateAsync(applicationUser);

            applicationUser.EmailConfirmed = true;
            applicationUser.LockoutEnabled = !model.IsActive;
            await _userManager.UpdateAsync(applicationUser);

            var result = await _userManager.AddPasswordAsync(applicationUser, model.password);
            if (!result.Succeeded)
            {
                Console.WriteLine(result.Errors.FirstOrDefault()?.Description);
            }

            if (model.Roles.Any())
            {
                foreach (var role in model.Roles)
                {
                    await _userManager.AddToRoleAsync(applicationUser, role);
                }
            }

            return await GetByIdAsync(applicationUser.Id);
        }

        public async Task<ApplicationUserDto> UpdateAsync(ApplicationUserModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user is not null || user.IsDeleted is false)
            {
                user.FullName = model.FullName;
                user.LockoutEnabled = !model.IsActive;

                await _userManager.SetUserNameAsync(user, model.UserName);
                await _userManager.SetEmailAsync(user, model.Email);
                await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);

                var result = await _userManager.UpdateAsync(user);

                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                if (model.Roles.Any())
                {
                    foreach (var role in model.Roles)
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }
            }

            return await GetByIdAsync(model.Id);
        }
        public async Task DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is not null && user.IsDeleted is false)
            {
                Random rnd = new Random();
                int randomInt = rnd.Next(1000, 10000);

                user.IsDeleted = true;
                user.LockoutEnabled = true;
                user.Email = "del-" + randomInt + "-" + user.Email;
                user.UserName = "del-" + randomInt + "-" + user.UserName;

                await _userManager.UpdateAsync(user);
                await _userManager.UpdateNormalizedUserNameAsync(user);
                await _userManager.UpdateNormalizedEmailAsync(user);

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var item in userRoles)
                {
                    await _userManager.RemoveFromRoleAsync(user, item);
                }
            }
        }




    }
}