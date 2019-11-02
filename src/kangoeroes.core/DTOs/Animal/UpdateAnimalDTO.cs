using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Animal
{
  public class UpdateAnimalDTO
  {
    [Required(AllowEmptyStrings = true)] public string Naam { get; set; }
  }
}
