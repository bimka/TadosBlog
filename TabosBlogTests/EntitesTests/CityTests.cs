using TadosBlog.Domain.Entities;

namespace TabosBlogTests.EntitesTests
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        public void CreateCityTest()
        {
            City city = new City(1, "Moscow");

            Assert.AreEqual("Moscow", city.Name);
        }
    }
}
