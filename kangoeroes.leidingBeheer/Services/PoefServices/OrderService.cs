
using System.Linq;
using System.Threading.Tasks;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Data.Repositories.PoefRepositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.Services.PoefServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Order;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Orderline;

namespace kangoeroes.leidingBeheer.Services.PoefServices
{
  /// <summary>
  /// Service voor het beheren van orders.
  /// </summary>
  public class OrderService : IOrderService
  {
    private readonly IOrderRepository _orderRepository;
    private readonly ILeidingRepository _leidingRepository;
    private readonly IDrankRepository _drankRepository;
    private readonly IOrderlineRepository _orderlineRepository;

    /// <summary>
    /// Maakt een nieuwe instantie van de OrderService klasse
    /// </summary>
    /// <param name="orderRepository">Geïnjecteerde repository om data uit de databank te lezen en schrijven.</param>
    public OrderService(IOrderRepository orderRepository, ILeidingRepository leidingRepository, IDrankRepository drankRepository, IOrderlineRepository orderlineRepository)
    {
      _orderRepository = orderRepository;
      _leidingRepository = leidingRepository;
      _drankRepository = drankRepository;
      _orderlineRepository = orderlineRepository;
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

    /// <summary>
    /// Haalt een order met de gegeven sleutel op
    /// </summary>
    /// <param name="orderId">Unieke sleutel van het order</param>
    /// <returns>De gevonden order</returns>
    /// <exception cref="EntityNotFoundException">Wordt gegooid wanneer er voor de gegeven sleutel geen order werd gevonden.</exception>
    public async Task<Order> GetOrderById(int orderId)
    {
      var order = await _orderRepository.FindByIdAsync(orderId);

      if (order == null)
      {
        throw new EntityNotFoundException($"Order met id {orderId} werd niet gevonden");
      }

      return order;

    }

    /// <summary>
    /// Creert een order uit het gegeven viewmodel
    /// </summary>
    /// <param name="viewModel">Viewmodel met de nodige data voor het aanmaken van een nieuw order</param>
    /// <returns>Nieuw aangemaakt order</returns>
    /// <exception cref="EntityNotFoundException">Wordt gegooid wanneer een persoon in het order of in een orderline niet gevonden werd.</exception>
    public async Task<Order> CreateOrder(CreateOrderViewModel viewModel)
    {
      var orderedBy = await _leidingRepository.FindByIdAsync(viewModel.OrderedById);

      if (orderedBy == null)
      {
        throw new EntityNotFoundException($"Besteller met id {viewModel.OrderedById} werd niet gevonden.");
      }

      var newOrder = Order.Create(orderedBy);

      await  _orderRepository.AddAsync(newOrder);

      foreach (var lineModel in viewModel.Orderlines)
      {
        var drank = await _drankRepository.FindByIdAsync(lineModel.DrankId);

        if (drank == null)
        {
          throw new EntityNotFoundException($"Drank met id {lineModel.DrankId} werd niet gevonden");
        }

        var orderedFor = await _leidingRepository.FindByIdAsync(lineModel.OrderedForId);

        if (orderedFor == null)
        {
          throw new EntityNotFoundException($"Persoon met id {lineModel.OrderedForId} werd niet gevonden.");
        }

        var orderline = Orderline.Create(drank, orderedFor, newOrder, lineModel.Quantity);

      await  _orderlineRepository.AddAsync(orderline);
      }

      await _orderRepository.SaveChangesAsync();

      return newOrder;
    }


    public async Task<Order> UpdateOrder(UpdateOrderViewModel viewModel, int orderId)
    {
      var order = await _orderRepository.FindByIdAsync(orderId);

      if (order == null)
      {
        throw new EntityNotFoundException($"Order met id {orderId} werd niet gevonden.");
      }

      bool shouldUpdate = viewModel.OrderedById != order.OrderedBy.Id;

      if (shouldUpdate)
      {
        var leiding = await _leidingRepository.FindByIdAsync(viewModel.OrderedById);

        if (leiding == null)
        {
          throw new EntityNotFoundException($"Persoon met id {viewModel.OrderedById} werd niet gevonden.");
        }

        order.OrderedBy = leiding;

        await _orderRepository.SaveChangesAsync();
      }

      return order;
    }

    public async Task<Orderline> UpdateOrderline(UpdateOrderlineViewModel viewModel, int orderId, int orderLineId)
    {
      var order = await _orderRepository.FindByIdAsync(orderId);

      if (order == null)
      {
        throw new EntityNotFoundException($"Order met id {orderId} werd niet gevonden.");
      }

      var orderline = order.Orderlines.FirstOrDefault(x => x.Id == orderLineId);

      if (orderline == null)
      {
        throw new EntityNotFoundException($"Orderline met id {orderLineId} werd niet gevonden in het order.");
      }

      var shouldUpdateDrank = viewModel.DrankId != orderline.Drank.Id;

      if (shouldUpdateDrank)
      {
        var newDrank = await _drankRepository.FindByIdAsync(viewModel.DrankId);

        if (newDrank == null)
        {
          throw new EntityNotFoundException($"Drank met id {viewModel.DrankId} werd niet gevonden;");

        }

        orderline.Drank = newDrank;
      }

      var shouldUpdateOrderedFor = orderline.OrderedFor.Id != viewModel.OrderedFor;

      if (shouldUpdateOrderedFor)
      {
        var newPerson = await _leidingRepository.FindByIdAsync(viewModel.OrderedFor);

        if (newPerson == null)
        {
          throw new EntityNotFoundException($"Persoon met id {viewModel.OrderedFor} werd niet gevonden.");
        }

        orderline.OrderedFor = newPerson;
      }

      orderline.Quantity = viewModel.Quantity;

      await _orderlineRepository.SaveChangesAsync();

      return orderline;
    }
  }
}
