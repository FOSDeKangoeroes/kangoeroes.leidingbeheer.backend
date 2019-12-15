using System.Linq;
using AutoMapper;
using kangoeroes.core.DTOs.Tab.Drink;
using kangoeroes.core.DTOs.Tab.DrinkType;
using kangoeroes.core.DTOs.Tab.Order;
using kangoeroes.core.DTOs.Tab.Orderline;
using kangoeroes.core.DTOs.Tab.Price;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.webUI.Profiles
{
  public class PoefProfile : Profile
  {
    public PoefProfile()
    {
      CreateMap<Drank, BasicDrinkDTO>();
      CreateMap<DrankType, BasicDrinkTypeDTO>();
      CreateMap<Order, BasicOrderDTO>().ForMember(x => x.OrderPrice, y => y.MapFrom(x => x.Orderlines.Sum(line => line.DrinkPrice * line.Quantity)));
      CreateMap<Orderline, BasicOrderlineDTO>();
      CreateMap<Prijs, BasicPriceDTO>();
    }
  }
}
