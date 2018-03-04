using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Models.AuthViewModels
{
  public class UserViewModel
  {
    [JsonProperty("user_id")]
    public string UserId { get; set; }
  }
}
