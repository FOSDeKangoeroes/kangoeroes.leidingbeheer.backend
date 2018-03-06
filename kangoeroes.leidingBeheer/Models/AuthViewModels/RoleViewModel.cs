using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace kangoeroes.leidingBeheer.Models.AuthViewModels
{
  public class RoleViewModel
  {
    [JsonProperty("_id")]
    public string Id { get; set; }
    public string Name { get; set; }
  }
}
