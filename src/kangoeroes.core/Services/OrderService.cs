using System;
using System.Linq;
using System.Threading.Tasks;
using kangoeroes.core.DTOs.Tab.Order;
using kangoeroes.core.DTOs.Tab.Orderline;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Accounting;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Services
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
        private readonly IAccountRepository _accountRepository;


        /// <summary>
        /// Maakt een nieuwe instantie van de OrderService klasse
        /// </summary>
        /// <param name="orderRepository">Geïnjecteerde repository om data uit de databank te lezen en schrijven.</param>
        public OrderService(IOrderRepository orderRepository, ILeidingRepository leidingRepository, IDrankRepository drankRepository, IOrderlineRepository orderlineRepository, IAccountRepository accountRepository)
        {
            _orderRepository = orderRepository;
            _leidingRepository = leidingRepository;
            _drankRepository = drankRepository;
            _orderlineRepository = orderlineRepository;
            _accountRepository = accountRepository;
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
        /// <param name="dto">Viewmodel met de nodige data voor het aanmaken van een nieuw order</param>
        /// <returns>Nieuw aangemaakt order</returns>
        /// <exception cref="EntityNotFoundException">Wordt gegooid wanneer een persoon in het order of in een orderline niet gevonden werd.</exception>
        public async Task<Order> CreateOrder(CreateOrderDTO dto)
        {
            var orderedBy = await _leidingRepository.FindByIdAsync(dto.OrderedById);

            if (orderedBy == null)
            {
                throw new EntityNotFoundException($"Besteller met id {dto.OrderedById} werd niet gevonden.");
            }

            var newOrder = Order.Create(orderedBy);

            await _orderRepository.AddAsync(newOrder);

            foreach (var lineModel in dto.Orderlines)
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

                var personCanOrder = orderedFor.Tak.TabIsAllowed;

                if (!personCanOrder)
                {
                    throw new InvalidOperationException($"Leden van {orderedFor.Tak.Naam} kunnen geen gebruik maken van de Poef.");
                }

                var orderline = Orderline.Create(drank, orderedFor, newOrder, lineModel.Quantity);


                await _orderlineRepository.AddAsync(orderline);
                
                //Create a transaction for the submitted order
                var amount = orderline.DrinkPrice * orderline.Quantity;
                amount = -amount;
                var transaction = new Transaction(amount, $"{orderline.Quantity}x {orderline.Drank.Naam}");
                
                var account = await _accountRepository.FindAccountAsync(orderedFor.Id, AccountType.Tab);

                if (account == null)
                {
                    throw new EntityNotFoundException($"Er werd geen poefaccount gevonden voor {orderedFor.Voornaam}.");
                }
                
                account.AddTransaction(transaction);
            }

            await _orderRepository.SaveChangesAsync();

            return newOrder;
        }


        public async Task<Order> UpdateOrder(UpdateOrderDTO dto, int orderId)
        {
            var order = await _orderRepository.FindByIdAsync(orderId);

            if (order == null)
            {
                throw new EntityNotFoundException($"Order met id {orderId} werd niet gevonden.");
            }

            bool shouldUpdate = dto.OrderedById != order.OrderedBy.Id;

            if (shouldUpdate)
            {
                var leiding = await _leidingRepository.FindByIdAsync(dto.OrderedById);

                if (leiding == null)
                {
                    throw new EntityNotFoundException($"Persoon met id {dto.OrderedById} werd niet gevonden.");
                }

                order.OrderedBy = leiding;

                await _orderRepository.SaveChangesAsync();
            }

            return order;
        }

        public async Task<Orderline> UpdateOrderline(UpdateOrderlineDTO dto, int orderId, int orderLineId)
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

            var shouldUpdateDrank = dto.DrankId != orderline.Drank.Id;

            if (shouldUpdateDrank)
            {
                var newDrank = await _drankRepository.FindByIdAsync(dto.DrankId);

                if (newDrank == null)
                {
                    throw new EntityNotFoundException($"Drank met id {dto.DrankId} werd niet gevonden;");

                }

                orderline.Drank = newDrank;
            }

            var shouldUpdateOrderedFor = orderline.OrderedFor.Id != dto.OrderedFor;

            if (shouldUpdateOrderedFor)
            {
                var newPerson = await _leidingRepository.FindByIdAsync(dto.OrderedFor);

                if (newPerson == null)
                {
                    throw new EntityNotFoundException($"Persoon met id {dto.OrderedFor} werd niet gevonden.");
                }

                orderline.OrderedFor = newPerson;
            }

            orderline.Quantity = dto.Quantity;

            await _orderlineRepository.SaveChangesAsync();

            return orderline;
        }

        public async Task<Order> DeleteOrder(int orderId)
        {
            var orderToDelete = await _orderRepository.FindByIdAsync(orderId);

            if (orderToDelete == null)
            {
                throw new EntityNotFoundException($"Order met id {orderId} werd niet gevonden.");
            }

            _orderRepository.Delete(orderToDelete);

            await _orderRepository.SaveChangesAsync();

            return orderToDelete;

        }

        public async Task<Orderline> DeleteOrderline(int orderId, int orderlineId)
        {
            var order = await _orderRepository.FindByIdAsync(orderId);

            if (order == null)
            {
                throw new EntityNotFoundException($"Order met id {orderId} werd niet gevonden.");
            }

            var orderlineToDelete = order.Orderlines.FirstOrDefault(x => x.Id == orderlineId);

            _orderlineRepository.Delete(orderlineToDelete);

            await _orderlineRepository.SaveChangesAsync();

            return orderlineToDelete;
        }
    }
}
