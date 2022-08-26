using System.ComponentModel.DataAnnotations;

namespace FitemaEntity.Requests
{
    public class ProductRequest
    {
        [Required]
        public int OrgId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Period { get; set; }
        public int Promo { get; set; }
    }
}
