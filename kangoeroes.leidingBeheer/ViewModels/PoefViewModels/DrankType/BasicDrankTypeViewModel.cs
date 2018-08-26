using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.ViewModels.PoefViewModels.DrankType
{
  public class BasicDrankTypeViewModel
  {
    public int Id { get; set; }

    public string Naam { get; set; }

    public string Afkorting => AfkortingBuilder.BuildAfkorting(Naam);
  }
}
