﻿using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.ViewModels.Adjectief
{
  public class UpdateAdjectiefViewModel
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
