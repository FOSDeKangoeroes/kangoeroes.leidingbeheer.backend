using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.ViewModels.Totem
{
  public class AddTotemViewModel
  {
    [Required(AllowEmptyStrings = false)]
    public string Naam { get; set; }
  }
}
