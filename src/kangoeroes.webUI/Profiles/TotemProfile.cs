using System.Collections.Generic;
using AutoMapper;
using kangoeroes.core.DTOs.Animal;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.webUI.Profiles
{
  public class TotemProfile : Profile
  {
    public TotemProfile()
    {
      CreateMap<Totem, BasicAnimalDTO>();
      CreateMap<AddAnimalDTO, Totem>();
      CreateMap<PagedList<Totem>, PagedList<BasicAnimalDTO>>().AfterMap((s, d) => CreateMap<IEnumerable<Totem>, IEnumerable<BasicAnimalDTO>>());
    }
  }
}
