using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.webUI.ViewModels.LeidingViewModels;

namespace kangoeroes.webUI.Profiles
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
