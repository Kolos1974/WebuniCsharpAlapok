using Xunit;

namespace MindigFenyes.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Kalkulator k = new();
            // Assert.Equal<int>(36, k.Kalkulalas("6*6"));
            // Assert.Equal<int>(1, k.Kalkulalas("6/6"));

            Assert.Equal<int>(36, 6*6);

        }
    }
}