using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Enum;
using Microsoft.AspNetCore.Identity;

namespace FreelanceManagerAPI.Data._seed
{
    public static class SeedData
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var roles = new[]
            {
            ApplicationUserRoles.Admin,
            ApplicationUserRoles.Normal
        };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
            }

            var Admins = new[]
            {
            new { Email = "ricardo.lima@ipvc.pt", UserName = "ricardoLima", Password = "Freelance@es2", FullName = "Ricardo Lima" },
            new { Email = "goncalo.p@ipvc.pt", UserName = "goncaloPeixoto", Password = "Freelance@es2", FullName = "Gonçalo Peixoto" },
            new { Email = "rodrigomesquita@ipvc.pt", UserName = "rodrigoMesquita", Password = "Freelance@es2", FullName = "Rodrigo Mesquita" },
            new { Email = "lucas.andrade@ipvc.pt", UserName = "lucasAndrade", Password = "Freelance@es2", FullName = "Lucas Andrade" },
            new { Email = "f.ricardo.fernandes@ipvc.pt", UserName = "filipeRicardo", Password = "Freelance@es2", FullName = "Filipe Ricardo" },
            new { Email = "andre.maia@ipvc.pt", UserName = "andreMaia", Password = "Freelance@es2", FullName = "André Maia" },
        };

            foreach (var sa in Admins)
            {
                var admin = await userManager.FindByEmailAsync(sa.Email);

                if (admin == null)
                {
                    admin = new ApplicationUser
                    {
                        UserName = sa.UserName,
                        Email = sa.Email,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = false,
                        FullName = sa.FullName,
                        CreatedBy = "Super",
                        UpdatedBy = ""

                    };

                    var result = await userManager.CreateAsync(admin, sa.Password);
                    if (result.Succeeded)
                    {
                        admin.LockoutEnabled = false;
                        admin.EmailConfirmed = true;
                        await userManager.UpdateAsync(admin);

                        await userManager.AddToRoleAsync(admin, ApplicationUserRoles.Admin);
                    }
                    else
                    {
                        throw new Exception($"Failed to create SuperAdmin user ({sa.Email}): {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    if (!await userManager.IsInRoleAsync(admin, ApplicationUserRoles.Admin))
                        await userManager.AddToRoleAsync(admin, ApplicationUserRoles.Admin);
                }
            }
        }
    }
}