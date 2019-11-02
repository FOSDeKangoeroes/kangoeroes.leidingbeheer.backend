using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.Tab.Order
{
  /// <summary>
  /// Model die de data bevat die nodig is om een order te wijzigen.
  /// </summary>
  public class UpdateOrderDTO
  {

    /// <summary>
    /// Unieke sleutel van de persoon die de bestelling heeft geplaatst.
    /// </summary>
    [Required]
    public int OrderedById { get; set; }

  }
}
