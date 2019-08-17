using AutoMapper;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.ViewModels.PoefViewModels.Drank;
using kangoeroes.webUI.ViewModels.PoefViewModels.DrankType;
using kangoeroes.webUI.ViewModels.PoefViewModels.Order;
using kangoeroes.webUI.ViewModels.PoefViewModels.Orderline;
using kangoeroes.webUI.ViewModels.PoefViewModels.Prijs;

namespace kangoeroes.webUI.Profiles
{
  public class PoefProfile : Profile
  {
    public PoefProfile()
    {
      CreateMap<Drank, BasicDrankViewModel>();
      CreateMap<DrankType, BasicDrankTypeViewModel>();
      CreateMap<Order, BasicOrderViewModel>();
      CreateMap<Orderline, BasicOrderlineViewModel>();
      CreateMap<Prijs, BasicPrijsViewModel>();
    }
  }
}
