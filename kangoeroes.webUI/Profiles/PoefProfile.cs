using AutoMapper;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.DTOs.PoefViewModels.Drank;
using kangoeroes.webUI.DTOs.PoefViewModels.DrankType;
using kangoeroes.webUI.DTOs.PoefViewModels.Order;
using kangoeroes.webUI.DTOs.PoefViewModels.Orderline;
using kangoeroes.webUI.DTOs.PoefViewModels.Prijs;

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
