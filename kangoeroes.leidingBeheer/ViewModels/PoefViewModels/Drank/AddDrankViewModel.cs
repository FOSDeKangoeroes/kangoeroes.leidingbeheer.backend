using System.ComponentModel.DataAnnotations;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.webUI.ViewModels.PoefViewModels.Drank
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
