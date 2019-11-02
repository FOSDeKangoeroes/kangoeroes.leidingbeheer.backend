using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.TotemViewModels
{
  public class AddTotemViewModel
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
