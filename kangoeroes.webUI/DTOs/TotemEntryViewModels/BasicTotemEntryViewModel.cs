using System;
using kangoeroes.webUI.DTOs.Adjective;
using kangoeroes.webUI.DTOs.Leader;
using kangoeroes.webUI.DTOs.TotemViewModels;
using Newtonsoft.Json;

namespace kangoeroes.webUI.DTOs.TotemEntryViewModels
{
  public class BasicTotemEntryViewModel
  {
    public int Id { get; set; }


    public DateTime DatumGegeven { get; set; }

    public string LeidingNaam { get; set; }

    public string LeidingVoornaam { get; set; }

    public BasicLeaderDTO Leiding { get; set; }

    public BasicTotemViewModel Totem { get; set; }

    public BasicAdjectiveDTO Adjectief { get; set; }

    public int VoorouderId { get; set; }

    [JsonProperty("voorouderTotem")] public string VoorouderTotemNaam { get; set; }

    [JsonProperty("voorouderAdjectief")] public string VoorouderAdjectiefNaam { get; set; }

    public DateTime ReuseDateTotem { get; set; }
    public DateTime ReuseDateAdjectief { get; set; }
  }
}
