namespace FitemaEntity.Models
{
    public class Bills : BaseModel
    {
        public Bills()
        {
        }
        public int OrgId { get; set; }
        public int PlanId { get; set; }
        public string VoucherCode { get; set; }
        public int TotalPayment { get; set; }
        public int StatusId { get; set; }
    }
}
