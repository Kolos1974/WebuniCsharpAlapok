using ConsoleApp61;

namespace NUnitTProj
{

    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SzamoloTeszt()
        {
            Szamolo s = new();

            Assert.AreEqual(s.Osszad(11, 22), 33);
            Assert.AreEqual(s.Kivon(44, 14), 30);

        }

        [TestCase(6,2,3)]
        [TestCase(8,2,4)]
        [TestCase(0,8,0)]
      
        public void SZamoloOsztTeszt(int o1, int o2, int ex)
        {
            Szamolo s = new();
            Assert.AreEqual(ex, s.Oszt(o1, o2));

        }


        [TestCase("6*8")]
        [TestCase("6+8")]
        [TestCase("6-8")]
        [TestCase("6/8")]
        public void SzeparatorTeszt(string mu)
        {
            Szeparator sz = new Szeparator(mu);
            Assert.IsTrue(sz.Valid);

        }


        [TestCase("6*8*")]
        [TestCase("68+")]
        [TestCase("-68")]
        [TestCase("/")]
        public void SzeparatorNegTeszt(string mu)
        {
            Szeparator sz = new Szeparator(mu);
            Assert.IsTrue(!sz.Valid);

        }

    }
}