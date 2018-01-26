namespace kangoeroes.core.Models.Responses
{
    public class ApiServerErrorResponse: ApiResponse
    {
        public string DetailedMessage { get; set; }
        public string StackTrace { get; set; }
        
        public ApiServerErrorResponse(string message) : base(500, message)
        {
           
        }
    }
}