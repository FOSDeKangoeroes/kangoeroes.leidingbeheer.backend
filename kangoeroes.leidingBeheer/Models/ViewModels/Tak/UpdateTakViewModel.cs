using System;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.Models.ViewModels.Tak
{
  public class UpdateTakViewModel : AddTakViewModel
  {

    public int Id { get; set; }


    public UpdateTakViewModel(string naam, int volgorde) : base(naam, volgorde)
    {

    }
  }
}
