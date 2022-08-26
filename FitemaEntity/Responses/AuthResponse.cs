using FitemaEntity.Models;

namespace FitemaEntity.Responses
{
    public class AuthResponse
    {
        public AuthResponse(Users user, string token)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            Role = user.Role;
            OrgId = user.OrgId;
            Token = token;
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int OrgId { get; set; }
        public string Token { get; set; }
    }
}
