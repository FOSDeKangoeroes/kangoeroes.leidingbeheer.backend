using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.Tab.Drink
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
