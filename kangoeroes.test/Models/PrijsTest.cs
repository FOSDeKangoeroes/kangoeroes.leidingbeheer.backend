using kangoeroes.core.Models.Poef;
using Xunit;

namespace kangoeroes.test.Models
{
    public class PrijsTest
    {
        public PrijsTest()
        {
            
        }
        
        /// <summary>
        /// Controleren of de factory methode prijzen de gegeven waarde correct toekent aan een prijs object.
        /// </summary>
        [Fact]
        public void CreateReturnsNewPriceWithCorrectValue()
        {
            var value = new decimal(0.65);

            var prijs = Prijs.Create(value);
            
            Assert.Equal(value, prijs.Waarde);
        }
    }
}