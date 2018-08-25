using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.AdjectiefViewModels
{
  public class AddAdjectiefViewModel
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
