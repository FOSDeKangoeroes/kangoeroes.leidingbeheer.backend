using kangoeroes.core.Models.Poef;
using Xunit;

namespace kangoeroes.test.Models
{
    public class DrankTest
    {
        private readonly Drank _drank;
        private readonly string _naam = "Coca Cola";
        private readonly decimal _prijs = new decimal(0.25);
        private readonly DrankType _type = new DrankType();
        private readonly bool _inStock = true;

        public DrankTest()
        {
            _drank = Drank.Create(_naam, _prijs, _type, _inStock);
        }

        // Factory methode testen op toekennen waarden

        [Fact]
        public void FactoryMethodReturnsValidObject()
        {
            Assert.Equal(_naam, _drank.Naam);
            Assert.Equal(_prijs, _drank.CurrentPrijs.Waarde);
            Assert.Equal(_type, _drank.Type);
            Assert.Equal(_inStock, _drank.InStock);
        }

        //TryAddNewPrijs
        // 1. Drank zonder prijs (kan niet?)
        // 2. Nieuwe prijs toevoegen verschillend van huidige prijs
        // 3. Nieuwe prijs toevoegen zelfde als huidige prijs
        // 4. 2 verschillende prijzen toevoegen. 3e prijs toevoegen die hetzelfde is als eerste prijs

        [Fact]
        public void CurrentPrijsReturnsCorrectValueWhenNewPriceIsDifferentFromFirst()
        {
           //Arrange
            var newPrijs = new decimal(1);
            
            //Act
            _drank.TryAddNewPrijs(newPrijs);
            
            //Assert
            Assert.Equal(newPrijs, _drank.CurrentPrijs.Waarde);
            Assert.Equal(2, _drank.Prijzen.Count);
        }

        [Fact]
        public void CurrentPrijsRemainsTheSameIfSamePriceIsAdded()
        {
            var newPrijs = _prijs;
            
            _drank.TryAddNewPrijs(newPrijs);
            
            Assert.Equal(newPrijs, _drank.CurrentPrijs.Waarde);
            Assert.Equal(1, _drank.Prijzen.Count);
        }

        [Fact]
        public void PriceIsAddedCorrectlyWhenValueAlreadyPresentInList()
        {
            var firstNewPrijs = new decimal(1);
            var secondNewPrijs = _prijs;
            
            _drank.TryAddNewPrijs(firstNewPrijs);
            _drank.TryAddNewPrijs(secondNewPrijs);
            
            Assert.Equal(secondNewPrijs, _drank.CurrentPrijs.Waarde);
            Assert.Equal(3, _drank.Prijzen.Count);
        }


        // CurrentPrijs
        // 1. Geeft correcte prijs terug met 1 prijs in lijst
        // 2. geeft correcte prijs terug met 2 prijzen in lijst
        // 3. Geeft correcte prijs terug met 3 prijzen in lijst
    }
}