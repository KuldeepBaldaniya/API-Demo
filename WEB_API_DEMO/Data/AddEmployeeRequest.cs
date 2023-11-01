namespace WEB_API_DEMO.Data
{
    public class AddEmployeeRequest
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
        public string address { get; set; }
    }
}
