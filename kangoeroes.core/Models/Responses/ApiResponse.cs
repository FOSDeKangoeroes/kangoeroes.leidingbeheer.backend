using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace kangoeroes.core.Models.Responses
{
  /// <summary>
  /// Standaard response waarmee een willekeurig bericht kan terugegeven worden
  /// </summary>
  public class ApiResponse
  {

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; }


    public ApiResponse(string message = null)
    {
      Message = message;
    }

  }
}
