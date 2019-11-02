using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.Adjective
{
  public class UpdateAdjectiveDTO
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
