using System;
using kangoeroes.core.Models.Poef;
using Xunit;

namespace kangoeroes.test.Domain
{
    public class DrankTest
    {
        public DrankTest()
        {
            
        }
        
        // Factory methode testen op toekennen waarden

        [Fact]
        public void FactoryMethodReturnsValidObject()
        {
            const string naam = "Coca Cola";
            var prijs = new decimal(0.25);
            var type = new DrankType();
            var inStock = true;
            var drank = Drank.Create(naam, prijs, type, inStock);
            
            Assert.Equal(naam, drank.Naam);
            Assert.Equal(prijs, drank.CurrentPrijs.Waarde);
            Assert.Equal(type, drank.Type);
            Assert.Equal(inStock, drank.InStock);
        }
        
        //TryAddNewPrijs
        // 1. Drank zonder prijs (kan niet?)
        // 2. Nieuwe prijs toevoegen verschillend van huidige prijs
        // 3. Nieuwe prijs toevoegen zelfde als huidige prijs
        // 4. 2 verschillende prijzen toevoegen. 3e prijs toevoegen die hetzelfde is als eerste prijs
        
        
        // CurrentPrijs
        // 1. Geeft correcte prijs terug met 1 prijs in lijst
        // 2. geeft correcte prijs terug met 2 prijzen in lijst
        // 3. Geeft correcte prijs terug met 3 prijzen in lijst
    }
}