using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Order
{
  public class UpdateOrderViewModel
  {

    [Required]
    public int OrderId { get; set; }
  }
}
