using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Orderline
{
  public class CreateOrderlineViewModel
  {
    [Required]
    public int DrankId { get; set; }

    [Required]
    public int OrderedForId { get; set; }

  }
}
