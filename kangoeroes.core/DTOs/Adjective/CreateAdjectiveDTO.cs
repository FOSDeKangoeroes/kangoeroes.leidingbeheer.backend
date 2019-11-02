using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Adjective
{
  public class CreateAdjectiveDTO
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
