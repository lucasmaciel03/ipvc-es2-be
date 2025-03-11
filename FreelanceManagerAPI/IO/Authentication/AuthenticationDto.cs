namespace FreelanceManagerAPI.IO.Authentication
{
    public class AuthenticationDto
    {
        public AuthenticationDto() { }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
