namespace FitemaEntity.Models
{
    public class Vouchers : BaseModel
    {
        public Vouchers()
        {
        }
        public int PlanId { get; set; }
        public int Promo { get; set; }
        public string Code { get; set; }
    }
}

