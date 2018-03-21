using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Models.ViewModels.Totem;

namespace kangoeroes.leidingBeheer.Models.Profiles
{
  public class TotemProfile: Profile
  {
    public TotemProfile()
    {
      CreateMap<Totem, BasicTotemViewModel>();
      CreateMap<AddTotemViewModel, Totem>();
    }
  }
}
