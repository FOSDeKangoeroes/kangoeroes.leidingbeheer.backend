using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using kangoeroes.webUI.DTOs.PoefViewModels.Orderline;

namespace kangoeroes.webUI.DTOs.PoefViewModels.Order
{
  public class CreateOrderViewModel
  {
    [Required]
    public int OrderedById { get; set; }

    [Required]
    public List<CreateOrderlineViewModel> Orderlines { get; set; }
  }
}
