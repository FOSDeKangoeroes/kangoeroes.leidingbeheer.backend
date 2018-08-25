using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.ViewModels.TakViewModels;

namespace kangoeroes.leidingBeheer.Profiles
{
  public class TakProfile : Profile
  {
    public TakProfile()
    {
      CreateMap<AddTakViewModel, Tak>();
      CreateMap<UpdateTakViewModel, Tak>();
      CreateMap<Tak, BasicTakViewModel>();
    }
  }
}
