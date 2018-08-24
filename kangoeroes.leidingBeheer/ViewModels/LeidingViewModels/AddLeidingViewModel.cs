using System;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.LeidingViewModels
{
  public class AddLeidingViewModel
  {
    public AddLeidingViewModel(string naam, string voornaam, int takId)
    {
      Naam = naam;
      Voornaam = voornaam;
      TakId = takId;
    }

    public string Auth0Id { get; set; }

    [Required(ErrorMessage = "{0} is verplicht.")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "{0} moet minstens {2} karakter(s) lang zijn.")]
    public string Naam { get; set; }

    [Required(ErrorMessage = "{0} is verplicht.")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "{0} moet minstens {2} karakter(s) lang zijn.")]
    public string Voornaam { get; set; }

    [DataType(DataType.EmailAddress, ErrorMessage = "{0} moet een emailadres zijn")]
    public string Email { get; set; }

    [DataType(DataType.Date, ErrorMessage = "{0 moet een datum zijn.}")]
    public DateTime LeidingSinds { get; set; }

    [DataType(DataType.Date, ErrorMessage = "{0 moet een datum zijn.}")]
    public DateTime DatumGestopt { get; set; }

    [Display(Name = "Tak")]
    // [Required(ErrorMessage = "{0 is verplicht.}")]
    // [Range(1,Int32.MaxValue,ErrorMessage = "{0} moet minstens {1} zijn.")]
    public int TakId { get; set; }
  }
}
