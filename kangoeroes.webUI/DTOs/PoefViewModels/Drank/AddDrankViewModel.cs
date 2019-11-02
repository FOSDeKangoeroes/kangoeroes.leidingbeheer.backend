using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.PoefViewModels.Drank
{
  public class AddDrankViewModel
  {
    [Required(AllowEmptyStrings = false)]
    public string Naam { get; set; }
    public bool InStock { get; set; }
    [Required]
    public int TypeId { get; set; }
    [Required]
    public decimal Prijs { get; set; }

  }
}
