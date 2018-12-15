using Newtonsoft.Json;

namespace kangoeroes.webUI.ViewModels.AuthViewModels
{
  public class TokenViewModel
  {
    [JsonProperty("access_token")] public string AccessToken { get; set; }
  }
}
