using AutoMapper;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels;

namespace kangoeroes.leidingBeheer.ViewModels.Profiles
{
  public class PoefProfile : Profile
  {
    public PoefProfile()
    {
      CreateMap<Drank, BasicDrankViewModel>();
    }
  }
}
