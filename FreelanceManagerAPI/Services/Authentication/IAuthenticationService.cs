using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceManagerAPI.IO.Authentication;

namespace FreelanceManagerAPI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationDto> SignInAsync(SignInModel model);
    }
}