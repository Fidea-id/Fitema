using System.ComponentModel.DataAnnotations;

namespace FitemaEntity.Requests
{
    public class LoginRequest
    {
        public LoginRequest()
        {
        }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool? RememberMe { get; set; }
        public string? ReturnUrl { get; set; }

    }
}

