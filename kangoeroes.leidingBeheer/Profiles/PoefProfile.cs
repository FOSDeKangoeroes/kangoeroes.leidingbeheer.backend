using AutoMapper;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Drank;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.DrankType;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Order;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Orderline;

namespace kangoeroes.leidingBeheer.Profiles
{
  public class PoefProfile : Profile
  {
    public PoefProfile()
    {
      CreateMap<Drank, BasicDrankViewModel>();
      CreateMap<DrankType, BasicDrankTypeViewModel>();
      CreateMap<Order, BasicOrderViewModel>();
      CreateMap<Orderline, BasicOrderlineViewModel>();
    }
  }
}
