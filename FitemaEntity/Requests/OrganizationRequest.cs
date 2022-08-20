using System.ComponentModel.DataAnnotations;

namespace FitemaEntity.Requests
{
    public class OrganizationRequest
    {
        public OrganizationRequest() { }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
