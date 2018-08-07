using AutoMapper;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Models.PoefViewModels;

namespace kangoeroes.leidingBeheer.Models.Profiles
{
  public class PoefProfile: Profile
  {
    public PoefProfile()
    {
      CreateMap<Drank, BasicDrankViewModel>();
    }
  }
}
