using kangoeroes.core.Helpers;
using Newtonsoft.Json;

namespace kangoeroes.core.DTOs.Tab.Drink
{
  public class BasicDrinkDTO
  {
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Afkorting => AfkortingBuilder.BuildAfkorting(Naam);
    public bool InStock { get; set; }
    public int TypeId { get; set; }
    public string TypeNaam { get; set; }
    [JsonProperty("prijs")]
    public decimal CurrentPrijsWaarde { get; set; }
    public string ImageUrl { get; set; }
  }
}
