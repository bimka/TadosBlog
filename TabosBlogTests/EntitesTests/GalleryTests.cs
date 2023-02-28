using TadosBlog.Domain.Entities;
using TadosBlog.Domain.ValueObjects;

namespace TabosBlogTests.EntitesTests
{
    [TestClass]
    public class GalleryTests
    {
        [TestMethod]
        public void CreateGalleryTest()
        {
            User contentOwner = new User(1, "user1@gmail.com");
            string url = "https://ya.ru";
            IEnumerable<Voting> votings = new HashSet<Voting>();

            Gallery gallery = new Gallery(1, contentOwner, "Gallery's name", url, votings);

            Assert.AreEqual("user1@gmail.com", gallery.ContentOwner.Email);
            Assert.AreEqual("Gallery's name", gallery.Name);
            Assert.AreEqual("https://ya.ru", gallery.Url);
            Assert.AreEqual(0, gallery.Votings.Count());
        }
    }
}