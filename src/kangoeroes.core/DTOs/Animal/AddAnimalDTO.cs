using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Animal
{
  public class AddAnimalDTO
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
