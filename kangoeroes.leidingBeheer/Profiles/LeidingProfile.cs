using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.ViewModels.LeidingViewModels;

namespace kangoeroes.leidingBeheer.Profiles
{
  public class LeidingProfile : Profile
  {
    public LeidingProfile()
    {
      CreateMap<Leiding, BasicLeidingViewModel>();
      CreateMap<UpdateLeidingViewModel, Leiding>();
    }
  }
}
