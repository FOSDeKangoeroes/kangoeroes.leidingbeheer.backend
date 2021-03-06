﻿using System.Threading.Tasks;
using kangoeroes.core.DTOs.Tab.Order;
using kangoeroes.core.DTOs.Tab.Orderline;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Interfaces.Services
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
    Task<Order> CreateOrder(CreateOrderDTO dto, string userEmail);
    Task<Order> UpdateOrder(UpdateOrderDTO dto, int orderId);
    Task<Orderline> UpdateOrderline(UpdateOrderlineDTO dto, int orderId, int orderLineId);
    Task<Order> DeleteOrder(int orderId);
    Task<Orderline> DeleteOrderline(int orderId, int orderlineId);
  }
}
