﻿namespace FitemaEntity.Responses
{
    public class BillResponse
    {
        public int OrgId { get; set; }
        public int PlanId { get; set; }
        public string VoucherCode { get; set; }
        public int TotalPayment { get; set; }
        public int StatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
