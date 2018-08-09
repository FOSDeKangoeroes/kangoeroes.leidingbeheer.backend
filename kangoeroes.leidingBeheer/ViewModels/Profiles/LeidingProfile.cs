using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.ViewModels.ViewModels.Leiding;

namespace kangoeroes.leidingBeheer.ViewModels.Profiles
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
