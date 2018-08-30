using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Orderline;

namespace kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Order
{
  public class CreateOrderViewModel
  {
    [Required]
    public int OrderedById { get; set; }

    [Required]
    public List<CreateOrderlineViewModel> Orderlines { get; set; }
  }
}
