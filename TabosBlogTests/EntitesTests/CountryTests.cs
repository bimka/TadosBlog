using TadosBlog.Domain.Entities;

namespace TabosBlogTests.EntitesTests
{
    [TestClass]
    public class CountryTests
    {
        [TestMethod]
        public void CreateCountryTest()
        {
            Country country = new Country(1, "Russia");

            Assert.AreEqual("Russia", country.Name);
        }
    }
}
