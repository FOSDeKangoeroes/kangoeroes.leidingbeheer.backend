using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using kangoeroes.webUI.DTOs.Tab.Orderline;

namespace kangoeroes.webUI.DTOs.Tab.Order
{
  public class CreateOrderDTO
  {
    [Required]
    public int OrderedById { get; set; }

    [Required]
    public List<CreateOrderlineDTO> Orderlines { get; set; }
  }
}
