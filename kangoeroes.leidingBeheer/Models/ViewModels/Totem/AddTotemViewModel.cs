using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.Models.ViewModels.Totem
{
  public class AddTotemViewModel
  {
    [Required(AllowEmptyStrings = false)]
    public string Naam { get; set; }
  }
}
