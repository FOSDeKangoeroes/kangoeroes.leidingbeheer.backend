using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.ViewModels.AuthViewModels
{
  public class TokenViewModel
  {

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

  }
}
