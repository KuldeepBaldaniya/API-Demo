namespace API_DEMO.Common
{
    public class ServiceResponse
    {
        public StatusCodeEnum StatusCode { get; set; }
        public string Message { get; set; }
        public Object Response { get; set; }

        public ServiceResponse()
        {
                
        }
        public ServiceResponse(Object response)
        {
            Response = response;
        }

        public ServiceResponse(StatusCodeEnum statusCode, string message, Object response)
        {
            StatusCode = statusCode;
            Message = message;
            Response = response;
        }

        public ServiceResponse(StatusCodeEnum statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public enum StatusCodeEnum
        {
            OK = 200,
            CREATED = 201,
            BAD_REQUEST = 400,
            UNAUTHORIZED = 401,
            NOT_FOUND = 404,
            CONFLICT_OCCURS = 409,
            INTERNAL_SERVER_ERROR = 500
        }
    }
}
