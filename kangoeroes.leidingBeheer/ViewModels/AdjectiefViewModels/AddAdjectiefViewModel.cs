using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.ViewModels.AdjectiefViewModels
{
  public class AddAdjectiefViewModel
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
