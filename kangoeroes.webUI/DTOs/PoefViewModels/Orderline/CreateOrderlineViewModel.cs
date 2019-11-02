using System;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.PoefViewModels.Orderline
{
  public class CreateOrderlineViewModel
  {
    [Required]
    public int DrankId { get; set; }

    [Required]
    public int OrderedForId { get; set; }

    [Required]
    [Range(1, Int32.MaxValue, ErrorMessage = "Er moet minstens een hoeveelheid van {1} gegeven worden.")]
    public int Quantity { get; set; }

  }
}
