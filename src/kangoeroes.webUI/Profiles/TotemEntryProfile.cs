using AutoMapper;
using kangoeroes.core.DTOs.TotemEntry;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.webUI.Profiles
{
  public class TotemEntryProfile : Profile
  {
    public TotemEntryProfile()
    {
      CreateMap<TotemEntry, BasicTotemEntryDTO>();
    }
  }
}
