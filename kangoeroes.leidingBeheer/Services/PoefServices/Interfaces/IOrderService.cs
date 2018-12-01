﻿using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Order;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Orderline;

namespace kangoeroes.leidingBeheer.Services.PoefServices.Interfaces
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
    Task<Order> CreateOrder(CreateOrderViewModel viewModel);
    Task<Order> UpdateOrder(UpdateOrderViewModel viewModel, int orderId);
    Task<Orderline> UpdateOrderline(UpdateOrderlineViewModel viewModel, int orderId, int orderLineId);
    Task<Order> DeleteOrder(int orderId);
    Task<Orderline> DeleteOrderline(int orderId, int orderlineId);
  }
}