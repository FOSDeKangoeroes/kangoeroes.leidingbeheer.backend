using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace kangoeroes.leidingBeheer.Models.AuthViewModels
{
  public class RoleViewModel
  {
    [JsonProperty("_id")]
    public string Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object obj)
    {
      if (obj is RoleViewModel)
      {
        var newObj = (RoleViewModel) obj;

        return Id.Equals(newObj.Id);
      }

      return false;
    }
  }
}
