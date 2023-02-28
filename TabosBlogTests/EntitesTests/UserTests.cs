using TadosBlog.Domain.Entities;

namespace TabosBlogTests.EntitesTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CreateUserTest()
        {
            User user = new User(1, "user1@gmail.com");

            Assert.AreEqual("user1@gmail.com", user.Email);
        }
    }
}

