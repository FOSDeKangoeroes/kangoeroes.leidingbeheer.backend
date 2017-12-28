using System;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.Models.ViewModels.Leiding
{
  public class UpdateLeidingViewModel : AddLeidingViewModel
  {

    [Required(ErrorMessage = "{0 is verplicht.}")]
    [Range(1,Int32.MaxValue,ErrorMessage = "{0} moet minstens {1} zijn.")]
    public int Id { get; set; }

    public UpdateLeidingViewModel(int id, string naam, string voornaam, int takId) : base(naam, voornaam, takId)
    {
      Id = id;
    }
  }
}
