using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.Animal
{
  public class UpdateAnimalDTO
  {
    [Required(AllowEmptyStrings = true)] public string Naam { get; set; }
  }
}
