using System;
using kangoeroes.webUI.ViewModels.AdjectiefViewModels;
using kangoeroes.webUI.ViewModels.LeidingViewModels;
using kangoeroes.webUI.ViewModels.TotemViewModels;
using Newtonsoft.Json;

namespace kangoeroes.webUI.ViewModels.TotemEntryViewModels
{
  public class BasicTotemEntryViewModel
  {
    public int Id { get; set; }


    public DateTime DatumGegeven { get; set; }

    public string LeidingNaam { get; set; }

    public string LeidingVoornaam { get; set; }

    public BasicLeidingViewModel Leiding { get; set; }

    public BasicTotemViewModel Totem { get; set; }

    public BasicAdjectiefViewModel Adjectief { get; set; }

    public int VoorouderId { get; set; }

    [JsonProperty("voorouderTotem")] public string VoorouderTotemNaam { get; set; }

    [JsonProperty("voorouderAdjectief")] public string VoorouderAdjectiefNaam { get; set; }

    public DateTime ReuseDateTotem { get; set; }
    public DateTime ReuseDateAdjectief { get; set; }
  }
}
