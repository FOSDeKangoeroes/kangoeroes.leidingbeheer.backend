using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.ViewModels.AdjectiefViewModels
{
  public class UpdateAdjectiefViewModel
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
