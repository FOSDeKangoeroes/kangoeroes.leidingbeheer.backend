
using kangoeroes.webUI.Helpers;
using Xunit;

namespace kangoeroes.test.Helpers
{
    public class AfkortingBuilderTest
    {
        [Fact]
        public void StringWithOneWord()
        {
            var expected = "C";
            var value = "coca";

            var afkorting = AfkortingBuilder.BuildAfkorting(value);

            Assert.Equal(expected, afkorting);
        }

        [Fact]
        public void StringWithTwoWords()
        {
            var expected = "SA";
            var value = "Stella Artois";

            var afkorting = AfkortingBuilder.BuildAfkorting(value);
            
            Assert.Equal(expected, afkorting);
        }

        [Fact]
        public void StringWithThreeWords()
        {
            var expected = "BD";

            var value = "Bob de Bouwer";

            var afkorting = AfkortingBuilder.BuildAfkorting(value);
            
            Assert.Equal(expected, afkorting);
        }
    }
}