using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using kangoeroes.core.DTOs.Tab.Order;
using kangoeroes.core.DTOs.Tab.Orderline;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Accounting;
using kangoeroes.core.Models.Poef;
using kangoeroes.core.Services;
using Moq;
using Xunit;

namespace kangoeroes.test.Services
{
   public class OrderServiceTest
   {
       private readonly DrankType _defaultDrankType;
       private readonly Drank _defaultDrank;

        public OrderServiceTest()
        {
            _defaultDrankType = new DrankType();
            _defaultDrank = Drank.Create("Coca-Cola",1,_defaultDrankType, true);
        }
       
        [Fact]
        public void AddingAnOrderShouldGenerateTransactionWithNegativeAmount()
        {

        }

        [Fact]
        public void OrderShouldNotContainNegativeAmounts()
        {

        }

        [Fact]
        public async Task Cant_Place_Order_If_OrderedFor_Section_Cant_Use_Tab()
        {
            var section = new Tak()
            {
                TabIsAllowed = false
            };
            var person = new Leiding()
            {
                Tak = section
            };
            var account = new Account(AccountType.Tab);

            person.Accounts = new List<Account> {account};


            var order = Order.Create(person);
            var orderline = Orderline.Create(_defaultDrank, person, order, 1);
            
            var orderRepository = new Mock<IOrderRepository>();
            var leidingRepo = new Mock<ILeidingRepository>();
            leidingRepo.Setup(x => x.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult<Leiding>(person));
            var drankRepo = new Mock<IDrankRepository>();
            drankRepo.Setup(x => x.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult<Drank>(_defaultDrank));
            var orderlineRepo = new Mock<IOrderlineRepository>();
            
            var accountRepo = new Mock<IAccountRepository>();
            accountRepo.Setup(x => x.FindAccountAsync(It.IsAny<int>(), AccountType.Tab))
                .Returns(Task.FromResult<Account>(account));
            
            var accountService = new Mock<IAccountService>();
            
            var service = new OrderService(orderRepository.Object,leidingRepo.Object, drankRepo.Object,orderlineRepo.Object,accountRepo.Object, accountService.Object);

var orderlines = new List<CreateOrderlineDTO>();
orderlines.Add(item: new CreateOrderlineDTO
                          {
                              DrankId = 10,
                              OrderedForId = 10,
                              Quantity = 10
                          });

            var orderDto = new CreateOrderDTO()
            {
                OrderedById = 10,
                Orderlines = orderlines
            };


            await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateOrder(orderDto));
        }
    }
}
