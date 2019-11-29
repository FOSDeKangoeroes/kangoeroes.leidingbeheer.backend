using kangoeroes.core.Models;
using kangoeroes.core.Models.Poef;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace kangoeroes.test.Models
{
    public class OrderlineTest
    {
        private readonly Drank _drank;
        private readonly string _naam = "Coca Cola";
        private readonly decimal _prijs = new decimal(0.25);
        private readonly DrankType _type = new DrankType();
        private readonly bool _inStock = true;

        private readonly Leiding _leiding;
        private readonly Order _order;

        public OrderlineTest()
        {
            _drank = Drank.Create(_naam, _prijs, _type, _inStock);
            _leiding = new Leiding();
            _order = Order.Create(_leiding);
        }

        [Fact]
        public void OrderlineCantHaveANegativeQuantity() => Assert.Throws<ArgumentOutOfRangeException>(() => Orderline.Create(_drank, _leiding, _order, -10));

        [Fact]
        public void OrderlineCantHaveAZeroQuantity() => Assert.Throws<ArgumentOutOfRangeException>(() => Orderline.Create(_drank, _leiding, _order, 0));

    }
}
