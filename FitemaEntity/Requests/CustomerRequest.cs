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
    public class CustomerUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int OrgId { get; set; }
    }
}
