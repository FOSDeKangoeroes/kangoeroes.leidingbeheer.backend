using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.DTOs.TotemViewModels;

namespace kangoeroes.webUI.Profiles
{
  public class TotemProfile : Profile
  {
    public TotemProfile()
    {
      CreateMap<Totem, BasicTotemViewModel>();
      CreateMap<AddTotemViewModel, Totem>();
    }
  }
}
