using TadosBlog.Domain.Entities;
using TadosBlog.Domain.ValueObjects;

namespace TabosBlogTests.EntitesTests
{
    [TestClass]
    public class VideoTests
    {
        [TestMethod]
        public void CreateVideoTest()
        {
            User contentOwner = new User(1, "user1@gmail.com");
            string url = "https://www.youtube.com/watch?v=nqoFomiOc9M&list=PLbL3X-OQd8EJLEszyaYbDqxc9FFYRjqz2&index=4";
            IEnumerable<Voting> votings = new HashSet<Voting>();

            Video video = new Video(1, contentOwner, "Video's name", url, votings);

            Assert.AreEqual("user1@gmail.com", video.ContentOwner.Email);
            Assert.AreEqual("Video's name", video.Name);
            Assert.AreEqual(url, video.Url);
            Assert.AreEqual(0, video.Votings.Count());
        }
    }
}