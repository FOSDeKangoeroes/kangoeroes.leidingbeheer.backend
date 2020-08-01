using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Section
{
  public class UpdateSectionDTO
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Naam is verplicht.")]
    [StringLength(20, MinimumLength = 1, ErrorMessage = "Lengte van {0} moet tussen {2} en {1} liggen")]
    public string Naam { get; set; }

    [Required(ErrorMessage = "Volgorde is verplicht.")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} moet groter of gelijk aan {1} zijn")]
    public int Volgorde { get; set; }
    
    [Required(ErrorMessage = "TabIsAllowed is verplicht.")]
    public bool TabIsAllowed { get; set; }
  }
}
