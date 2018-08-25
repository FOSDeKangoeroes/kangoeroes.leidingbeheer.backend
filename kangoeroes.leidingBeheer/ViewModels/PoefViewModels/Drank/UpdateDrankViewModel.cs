﻿using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Drank
{
  public class UpdateDrankViewModel
  {
    [Required]
    public string Naam { get; set; }

    public bool InStock { get; set; }
    [Required]
    public decimal Prijs { get; set; }
  }
}
