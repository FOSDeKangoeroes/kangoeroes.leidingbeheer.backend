﻿using System;

namespace kangoeroes.leidingBeheer.ViewModels.ViewModels.TotemEntry
{
  public class UpdateTotemEntryViewModel
  {
    public int AdjectiefId { get; set; }
    public int TotemId { get; set; }
    public DateTime DatumGegeven { get; set; }
    public int VoorouderId { get; set; }
  }
}
