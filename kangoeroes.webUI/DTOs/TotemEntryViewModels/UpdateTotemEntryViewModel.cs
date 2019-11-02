using System;

namespace kangoeroes.webUI.DTOs.TotemEntryViewModels
{
  public class UpdateTotemEntryViewModel
  {
    public int AdjectiefId { get; set; }
    public int TotemId { get; set; }
    public DateTime DatumGegeven { get; set; }
    public int VoorouderId { get; set; }
  }
}
