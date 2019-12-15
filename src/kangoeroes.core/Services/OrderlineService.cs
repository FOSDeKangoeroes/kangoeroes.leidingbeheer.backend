using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Services
{
    public class OrderlineService: IOrderlineService
    {
        private readonly IOrderlineRepository _orderlineRepository;
        public OrderlineService(IOrderlineRepository orderlineRepository)
        {
            _orderlineRepository = orderlineRepository;
        }
        public PagedList<Orderline> GetAllOrderlines(OrderlineResourceParameters parameters)
        {
            return _orderlineRepository.FindAll(parameters);
        }
    }
}