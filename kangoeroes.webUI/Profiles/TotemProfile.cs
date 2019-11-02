using AutoMapper;
using kangoeroes.core.DTOs.Animal;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.webUI.Profiles
{
  public class TotemProfile : Profile
  {
    public TotemProfile()
    {
      CreateMap<Totem, BasicAnimalDTO>();
      CreateMap<AddAnimalDTO, Totem>();
    }
  }
}
