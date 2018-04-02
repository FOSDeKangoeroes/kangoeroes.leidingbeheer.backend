using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using kangoeroes.leidingBeheer.Models.ViewModels.Adjectief;
using kangoeroes.leidingBeheer.Models.ViewModels.Leiding;
using kangoeroes.leidingBeheer.Models.ViewModels.Totem;

namespace kangoeroes.leidingBeheer.Models.ViewModels.TotemEntry
{
  public class BasicTotemEntryViewModel
  {
    public int Id { get; set; }


    public DateTime DatumGegeven { get; set; }

    public BasicLeidingViewModel Leiding { get; set; }

    public BasicTotemViewModel Totem { get; set; }

    public BasicAdjectiefViewModel Adjectief { get; set; }

    public int VoorouderId { get; set; }
  }
}
