using System.ComponentModel.DataAnnotations;

namespace FitemaEntity.Requests
{
    public class BillRequest
    {
        public BillRequest() { }
        public int OrgId { get; set; }
        [Required]
        public int PlanId { get; set; }
        public string VoucherCode { get; set; }
        public int TotalPayment { get; set; }
        public int StatusId { get; set; }
    }
}
