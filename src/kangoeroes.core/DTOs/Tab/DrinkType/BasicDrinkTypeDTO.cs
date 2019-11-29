using kangoeroes.core.Helpers;

namespace kangoeroes.core.DTOs.Tab.DrinkType
{
  public class BasicDrinkTypeDTO
  {
    public int Id { get; set; }

    public string Naam { get; set; }

    public string Afkorting => AfkortingBuilder.BuildAfkorting(Naam);
  }
}
