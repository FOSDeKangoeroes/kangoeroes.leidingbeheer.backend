using AutoMapper;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.DTOs.Tab.Drink;
using kangoeroes.webUI.DTOs.Tab.DrinkType;
using kangoeroes.webUI.DTOs.Tab.Order;
using kangoeroes.webUI.DTOs.Tab.Orderline;
using kangoeroes.webUI.DTOs.Tab.Price;

namespace kangoeroes.webUI.Profiles
{
  public class PoefProfile : Profile
  {
    public PoefProfile()
    {
      CreateMap<Drank, BasicDrinkDTO>();
      CreateMap<DrankType, BasicDrankTypeViewModel>();
      CreateMap<Order, BasicOrderViewModel>();
      CreateMap<Orderline, BasicOrderlineViewModel>();
      CreateMap<Prijs, BasicPrijsViewModel>();
    }
  }
}
