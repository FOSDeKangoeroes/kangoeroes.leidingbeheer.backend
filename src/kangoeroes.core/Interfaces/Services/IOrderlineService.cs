using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Interfaces.Services
{
    public interface IOrderlineService
    {
        PagedList<Orderline> GetAllOrderlines(OrderlineResourceParameters parameters);
    }
}