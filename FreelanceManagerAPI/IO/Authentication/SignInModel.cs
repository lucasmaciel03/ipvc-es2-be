using System.ComponentModel.DataAnnotations;

namespace FreelanceManagerAPI.IO.Authentication
{
    public class SignInModel
    {
        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}