using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.IO.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FreelanceManagerAPI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthenticationDto> SignInAsync(SignInModel model)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user is not null && user.LockoutEnabled is false && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                IList<string> userRoles = await _userManager.GetRolesAsync(user);

                List<Claim> authClaims =
                    [
                        new Claim("id", user.Id),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        .. userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)),
                    ];

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddYears(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey,
                    SecurityAlgorithms.HmacSha256));

                return new AuthenticationDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                };
            }
            return null;
        }
    }
}