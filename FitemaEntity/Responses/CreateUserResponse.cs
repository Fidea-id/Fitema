namespace FitemaEntity.Responses
{
    public class CreateUserResponse
    {
        public CreateUserResponse(string email, string fullName, string role, string organizationName, string organizationAddress, string organizationDescription)
        {
            Email = email;
            FullName = fullName;
            Role = role;
            OrganizationName = organizationName;
            OrganizationAddress = organizationAddress;
            OrganizationDescription = organizationDescription;
        }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAddress { get; set; }
        public string OrganizationDescription { get; set; }
    }
}
