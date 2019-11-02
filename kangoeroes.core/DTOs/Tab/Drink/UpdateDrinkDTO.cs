using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Tab.Drink
{
  public class UpdateDrinkDTO
  {
    [Required]
    public string Naam { get; set; }

    public bool InStock { get; set; }
    [Required]
    public decimal Prijs { get; set; }
  }
}
