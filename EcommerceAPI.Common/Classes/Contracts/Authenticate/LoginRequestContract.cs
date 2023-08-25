namespace EcommerceAPI.Common.Classes.Contracts.Authenticate
{
    public class LoginRequestContract
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
