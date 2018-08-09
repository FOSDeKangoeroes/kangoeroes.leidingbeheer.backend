using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.ViewModels.AuthViewModels
{
  public class UserViewModel
  {
    [JsonProperty("user_id")]
    public string UserId { get; set; }
  }
}
