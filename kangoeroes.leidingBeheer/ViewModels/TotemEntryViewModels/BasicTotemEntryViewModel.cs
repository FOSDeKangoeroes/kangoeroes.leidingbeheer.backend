using System;
using kangoeroes.leidingBeheer.ViewModels.AdjectiefViewModels;
using kangoeroes.leidingBeheer.ViewModels.TotemViewModels;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.ViewModels.TotemEntryViewModels
{
  public class BasicTotemEntryViewModel
  {
    public int Id { get; set; }


    public DateTime DatumGegeven { get; set; }

    public string LeidingNaam { get; set; }

    public string LeidingVoornaam { get; set; }


    public BasicTotemViewModel Totem { get; set; }

    public BasicAdjectiefViewModel Adjectief { get; set; }

    public int VoorouderId { get; set; }

    [JsonProperty("voorouderTotem")] public string VoorouderTotemNaam { get; set; }

    [JsonProperty("voorouderAdjectief")] public string VoorouderAdjectiefNaam { get; set; }

    public DateTime ReuseDateTotem { get; set; }
    public DateTime ReuseDateAdjectief { get; set; }
  }
}
