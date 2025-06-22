namespace WebApi.Models.Responses
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }  // Ej: "USR_INVALID"
        public string Message { get; set; }

        public ApiErrorResponse(int statusCode, string errorCode, string message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Message = message;
        }
    }
}
