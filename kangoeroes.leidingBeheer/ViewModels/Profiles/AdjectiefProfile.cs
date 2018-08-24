using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.ViewModels.AdjectiefViewModels;

namespace kangoeroes.leidingBeheer.ViewModels.Profiles
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
