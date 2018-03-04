using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace kangoeroes.leidingBeheer.Models.AuthViewModels
{
  public class TokenViewModel
  {

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

  }
}
