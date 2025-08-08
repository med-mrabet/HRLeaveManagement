namespace HR.LeaveManagement.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
