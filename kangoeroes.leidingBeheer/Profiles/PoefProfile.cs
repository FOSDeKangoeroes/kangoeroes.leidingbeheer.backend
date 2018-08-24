using AutoMapper;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Drank;

namespace kangoeroes.leidingBeheer.Profiles
{
  public class PoefProfile : Profile
  {
    public PoefProfile()
    {
      CreateMap<Drank, BasicDrankViewModel>();
    }
  }
}
