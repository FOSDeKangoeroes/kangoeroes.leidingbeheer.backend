
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Repositories.PoefRepositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;

namespace kangoeroes.leidingBeheer.Services.PoefServices
{
  /// <summary>
  /// Service voor het beheren van orders.
  /// </summary>
  public class OrderService
  {
    private readonly IOrderRepository _orderRepository;

    /// <summary>
    /// Maakt een nieuwe instantie van de OrderService klasse
    /// </summary>
    /// <param name="orderRepository">Geïnjecteerde repository om data uit de databank te lezen en schrijven.</param>
    public OrderService(IOrderRepository orderRepository)
    {
      _orderRepository = orderRepository;
    }

    /// <summary>
    /// Lijst ophalen van alle orders, rekening houdend met de doorgegeven parameters.
    /// </summary>
    /// <param name="resourceParameters">Parameters voor filteren en sorteren</param>
    /// <returns></returns>
    public PagedList<Order> GetAllOrders(OrderResourceParameters resourceParameters)
    {
       return _orderRepository.FindAll(resourceParameters);

    }
  }
}
