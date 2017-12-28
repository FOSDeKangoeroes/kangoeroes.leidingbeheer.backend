using System;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.Models.ViewModels.Tak
{
  public class UpdateTakViewModel : AddTakViewModel
  {
    [Required(ErrorMessage = "{0} is verplicht.")]
    [Range(1,Int32.MaxValue,ErrorMessage = "{0} moet minstens {1} zijn")]
    public int Id { get; set; }


    public UpdateTakViewModel(int id, string naam, int volgorde) : base(naam, volgorde)
    {
      Id = id;
    }
  }
}
