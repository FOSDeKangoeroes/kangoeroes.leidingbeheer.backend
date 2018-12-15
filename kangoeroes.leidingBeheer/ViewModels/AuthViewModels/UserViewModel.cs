using Newtonsoft.Json;

namespace kangoeroes.webUI.ViewModels.AuthViewModels
{
  public class UserViewModel
  {
    [JsonProperty("user_id")] public string UserId { get; set; }
  }
}
