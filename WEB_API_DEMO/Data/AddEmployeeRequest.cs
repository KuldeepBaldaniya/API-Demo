using Swashbuckle.AspNetCore.Annotations;

namespace API_DEMO.Data
{
    public class AddEmployeeRequest
    {
        [SwaggerSchema("The ID of the user")]
        public Guid id { get; set; }
        [SwaggerSchema("The Name of the user")]
        public string name { get; set; }
        [SwaggerSchema("The Email of the user")]
        public string email { get; set; }
        [SwaggerSchema("The Phone of the user")]
        public long phone { get; set; }
        [SwaggerSchema("The Address of the user")]
        public string address { get; set; }
    }
}
