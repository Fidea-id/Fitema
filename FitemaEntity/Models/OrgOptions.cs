namespace FitemaEntity.Models
{
    public class OrgOptions : BaseModel
    {
        public OrgOptions() { }
        public int OrgId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
