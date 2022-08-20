namespace FitemaEntity.Models
{
    public class Transactions : BaseModel
    {
        public Transactions()
        {
        }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int OrgId { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OrderFrom { get; set; }
        public string DurationType { get; set; }
        public int StatusId { get; set; }
    }
}

