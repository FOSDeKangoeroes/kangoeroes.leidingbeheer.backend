using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.ViewModels.ViewModels.Tak;

namespace kangoeroes.leidingBeheer.ViewModels.Profiles
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
