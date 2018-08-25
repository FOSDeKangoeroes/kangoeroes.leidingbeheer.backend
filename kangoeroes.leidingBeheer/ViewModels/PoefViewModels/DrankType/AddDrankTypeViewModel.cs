using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.PoefViewModels.DrankType
{
  /// <summary>
  /// Representatie van data nodig om een nieuw dranktype aan te maken.
  /// </summary>
  public class AddDrankTypeViewModel
  {
    /// <summary>
    /// Naam van het toe te voegen type
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public string Naam { get; set; }
  }
}
