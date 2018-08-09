using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.ViewModels.ViewModels.TotemEntry;

namespace kangoeroes.leidingBeheer.ViewModels.Profiles
{
  public class TotemEntryProfile : Profile
  {
    public TotemEntryProfile()
    {
      CreateMap<TotemEntry, BasicTotemEntryViewModel>();
    }
  }
}
