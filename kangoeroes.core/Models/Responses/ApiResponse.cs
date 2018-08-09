using Newtonsoft.Json;

namespace kangoeroes.core.Models.Responses
{
  /// <summary>
  ///     Standaard response waarmee een willekeurig bericht kan terugegeven worden
  /// </summary>
  public class ApiResponse
    {
        public ApiResponse(string message = null)
        {
            Message = message;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }
    }
}