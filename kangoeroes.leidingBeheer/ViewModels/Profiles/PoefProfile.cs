using AutoMapper;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Drank;

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
