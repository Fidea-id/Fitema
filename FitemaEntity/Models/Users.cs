using System.Text.Json.Serialization;

namespace FitemaEntity.Models
{
    public class Users : BaseModel
    {
        public Users()
        {
        }

        public Users(string fullName, string email, string password, string role, int orgId)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
            OrgId = orgId;
        }

        public string FullName { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string Role { get; set; }
        public int OrgId { get; set; }
    }
}

