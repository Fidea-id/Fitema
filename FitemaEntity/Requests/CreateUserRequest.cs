using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitemaEntity.Requests
{
    public class CreateUserRequest
    {
        public CreateUserRequest(string email, string password, string fullName, string role, string organizationName, string organizationAddress, string organizationDescription)
        {
            Email = email;
            Password = password;
            FullName = fullName;
            Role = role;
            OrganizationName = organizationName;
            OrganizationAddress = organizationAddress;
            OrganizationDescription = organizationDescription;
        }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string OrganizationAddress { get; set; }
        public string OrganizationDescription { get; set; }
    }
}
