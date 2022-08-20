namespace FitemaEntity.Dtos.Auth
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int OrgId { get; set; }
        public string OrganizationName { get; set; }
    }
}
