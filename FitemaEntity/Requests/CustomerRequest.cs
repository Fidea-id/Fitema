using System.ComponentModel.DataAnnotations;

namespace FitemaEntity.Requests
{
    public class CustomerRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int OrgId { get; set; }
    }
}
