using System;
namespace Fitema.Models
{
    public class Customers : BaseModel
    {
        public Customers()
        {
        }
        public int OrgId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

