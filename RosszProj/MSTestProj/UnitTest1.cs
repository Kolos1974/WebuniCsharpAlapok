using ConsoleApp61;

namespace MSTestProj
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SzamoloTest()
        {
            Szamolo s = new Szamolo();

            Assert.AreEqual(20, s.Kivon(50, 30));
            Assert.AreEqual(40, s.Osszad(15, 25));
            Assert.AreEqual(15, s.Szoroz(5, 3));
            Assert.AreEqual(2, s.Oszt(60, 30));

        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SzeparatorUresTeszt()
        {
            Szeparator s = new Szeparator("");


        }

    }
}