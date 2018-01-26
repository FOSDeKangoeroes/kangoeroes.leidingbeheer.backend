namespace kangoeroes.core.Models.Responses
{
    public class ApiCreatedResponse: ApiResponse
    {
        public object Result { get; set; }
        public ApiCreatedResponse(object result) : base(201)
        {
            Result = result;
        }
    }
}