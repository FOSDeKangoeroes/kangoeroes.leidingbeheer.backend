using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.DTOs.Animal;

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
