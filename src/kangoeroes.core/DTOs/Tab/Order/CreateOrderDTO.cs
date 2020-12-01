using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using kangoeroes.core.DTOs.Tab.Orderline;

namespace kangoeroes.core.DTOs.Tab.Order
{
  public class CreateOrderDTO
  {
    [Required]
    public List<CreateOrderlineDTO> Orderlines { get; set; }
  }
}
