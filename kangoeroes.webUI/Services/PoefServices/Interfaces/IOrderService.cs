using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.DTOs.Tab.Order;
using kangoeroes.webUI.DTOs.Tab.Orderline;
using kangoeroes.webUI.Helpers;

namespace kangoeroes.webUI.Services.PoefServices.Interfaces
{
  public interface IOrderService
  {
    /// <summary>
    /// Lijst ophalen van alle orders, rekening houdend met de doorgegeven parameters.
    /// </summary>
    /// <param name="resourceParameters">Parameters voor filteren en sorteren</param>
    /// <returns></returns>
    PagedList<Order> GetAllOrders(OrderResourceParameters resourceParameters);

    Task<Order> GetOrderById(int orderId);
    Task<Order> CreateOrder(CreateOrderDTO dto);
    Task<Order> UpdateOrder(UpdateOrderDTO dto, int orderId);
    Task<Orderline> UpdateOrderline(UpdateOrderlineDTO dto, int orderId, int orderLineId);
    Task<Order> DeleteOrder(int orderId);
    Task<Orderline> DeleteOrderline(int orderId, int orderlineId);
  }
}
