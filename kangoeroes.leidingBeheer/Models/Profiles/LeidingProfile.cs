using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.Models.ViewModels.Leiding;

namespace kangoeroes.leidingBeheer.Models.Profiles
{
  public class LeidingProfile: Profile
  {
    public LeidingProfile()
    {
      CreateMap<Leiding, BasicLeidingViewModel>();
    }
  }
}
