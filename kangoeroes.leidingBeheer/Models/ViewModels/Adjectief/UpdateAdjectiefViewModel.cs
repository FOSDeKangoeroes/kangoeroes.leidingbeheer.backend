using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.Models.ViewModels.Adjectief
{
  public class UpdateAdjectiefViewModel
  {
    [Required(AllowEmptyStrings = false)]
    public string Naam { get; set; }
  }
}
