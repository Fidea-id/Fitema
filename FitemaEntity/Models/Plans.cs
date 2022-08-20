namespace FitemaEntity.Models
{
    public class Plans : BaseModel
    {
        public Plans()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Promo { get; set; }
        public int StatusId { get; set; }
    }
}

