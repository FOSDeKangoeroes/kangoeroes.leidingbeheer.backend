using System;
using kangoeroes.core.Helpers;

namespace kangoeroes.core.DTOs.Leader
{
  public class BasicLeaderDTO
  {
    public int Id { get; set; }

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
