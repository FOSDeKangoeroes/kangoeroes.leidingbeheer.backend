

using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.Models.ViewModels.Tak
{
  public class AddTakViewModel
  {
    [Required(ErrorMessage = "Naam is verplicht.")]
    public string Naam { get; set; }
    [Required(ErrorMessage = "Volgorde is verplicht.")]
    public int Volgorde { get; set; }
  }
}
