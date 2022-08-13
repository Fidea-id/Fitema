namespace Fitema.Models
{
    public class Bills:BaseModel
    {
        public Bills()
        {
        }
        public int OrdId { get; set; }
        public int PlanId { get; set; }
        public string VoucherCode { get; set; }
        public int TotalPayment { get; set; }
        public string Status { get; set; }
    }
}
