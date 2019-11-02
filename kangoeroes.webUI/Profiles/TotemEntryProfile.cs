using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.DTOs.TotemEntryViewModels;

namespace kangoeroes.webUI.Profiles
{
  public class TotemEntryProfile : Profile
  {
    public TotemEntryProfile()
    {
      CreateMap<TotemEntry, BasicTotemEntryViewModel>();
    }
  }
}
