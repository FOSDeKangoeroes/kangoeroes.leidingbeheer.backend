using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.ViewModels.Totem
{
  public class UpdateTotemViewModel
  {
    [Required(AllowEmptyStrings = true)] public string Naam { get; set; }
  }
}
