using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.Animal
{
  public class AddAnimalDTO
  {
    [Required(AllowEmptyStrings = false)] public string Naam { get; set; }
  }
}
