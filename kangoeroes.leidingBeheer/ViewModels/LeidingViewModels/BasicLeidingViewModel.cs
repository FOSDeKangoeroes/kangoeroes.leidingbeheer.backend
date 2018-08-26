using System;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.ViewModels.LeidingViewModels
{
  public class BasicLeidingViewModel
  {
    public int Id { get; set; }

    public string Auth0Id { get; set; }

    public string Naam { get; set; }

    public string Voornaam { get; set; }

    public string Afkorting => AfkortingBuilder.BuildAfkorting($"{Voornaam} {Naam}");

    public string Email { get; set; }

    public DateTime LeidingSinds { get; set; }

    public DateTime DatumGestopt { get; set; }

    public string TakNaam { get; set; }

    public int TakId { get; set; }
  }
}
