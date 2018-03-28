using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.leidingBeheer.Services.TotemServices.Interfaces
{
  public interface ITotemEntryService
  {
    PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters);
  }
}
