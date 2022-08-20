namespace FitemaEntity.Models
{
    public class Organizations: BaseModel
    {
        public Organizations()
        {
        }
        public Organizations(string name, string address, string description, int statusId)
        {
            Name = name;
            Address = address;
            Description = description;
            StatusId = statusId;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}

