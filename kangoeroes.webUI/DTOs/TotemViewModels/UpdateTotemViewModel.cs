using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.TotemViewModels
{
  public class UpdateTotemViewModel
  {
    [Required(AllowEmptyStrings = true)] public string Naam { get; set; }
  }
}
