using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Adjective
{
  public class UpdateAdjectiveDTO
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
