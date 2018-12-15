using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.ViewModels.AdjectiefViewModels;

namespace kangoeroes.webUI.Profiles
{
  public class AdjectiefProfile : Profile
  {
    public AdjectiefProfile()
    {
      CreateMap<Adjectief, BasicAdjectiefViewModel>();
      CreateMap<AddAdjectiefViewModel, Adjectief>();
      CreateMap<UpdateAdjectiefViewModel, Adjectief>();
    }
  }
}
