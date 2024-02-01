namespace TestBTlab.Models
{
    public class TimeSheet
    {
        public int Id { get; set; }
        public int employee { get; set; }
        public int reason { get; set; }
        public DateTime start_date { get; set; }
        public int duration { get; set; }
        public bool discounted { get; set; }
        public string description { get; set; }
    }
}
