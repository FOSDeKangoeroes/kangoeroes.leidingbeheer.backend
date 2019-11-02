using System;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.webUI.DTOs.TotemEntryViewModels
{
  public class AddEntryExistingLeiding
  {
    [Required] public int LeidingId { get; set; }

    [Required] public int TotemId { get; set; }

    [Required] public int AdjectiefId { get; set; }

    public DateTime DatumGegeven { get; set; }

    public int VoorouderId { get; set; }
  }
}
