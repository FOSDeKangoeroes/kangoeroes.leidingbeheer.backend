using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace kangoeroes.leidingBeheer.Models.Responses
{
  public class ApiResponse
  {
    public int StatusCode { get; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; }


    public ApiResponse(int statusCode, string message = null)
    {
      StatusCode = statusCode;
      Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    private static string GetDefaultMessageForStatusCode(int statusCode)
    {
      switch (statusCode)
      {
          case 404:
            return "Resource not found";
            case 500:
              return "An unhandled error occured";
              default:
                return null;
      }
      {

      }
    }
  }
}
