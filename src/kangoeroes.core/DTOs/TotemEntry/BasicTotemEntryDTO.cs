using System;
using kangoeroes.core.DTOs.Adjective;
using kangoeroes.core.DTOs.Animal;
using kangoeroes.core.DTOs.Leader;
using Newtonsoft.Json;

namespace kangoeroes.core.DTOs.TotemEntry
{
  public class BasicTotemEntryDTO
  {
    public int Id { get; set; }


    public DateTime DatumGegeven { get; set; }

    public string LeidingNaam { get; set; }

    public string LeidingVoornaam { get; set; }

    public BasicLeaderDTO Leiding { get; set; }

    public BasicAnimalDTO Totem { get; set; }

    public BasicAdjectiveDTO Adjectief { get; set; }

    public int VoorouderId { get; set; }

    [JsonProperty("voorouderTotem")] public string VoorouderTotemNaam { get; set; }

    [JsonProperty("voorouderAdjectief")] public string VoorouderAdjectiefNaam { get; set; }

    public DateTime ReuseDateTotem { get; set; }
    public DateTime ReuseDateAdjectief { get; set; }
  }
}
