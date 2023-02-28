using TadosBlog.Domain.Entities;
using TadosBlog.Domain.ValueObjects;

namespace TabosBlogTests.EntitesTests
{
    [TestClass]
    public class ArticleTests
    {
        [TestMethod]
        public void CreateArticleTest()
        {
            User contentOwner = new User(1, "user1@gmail.com");
            IEnumerable<Voting> votings = new HashSet<Voting>();

            Article article = new Article(1, contentOwner, "Article's name", "Article's text", votings);

            Assert.AreEqual("user1@gmail.com", article.ContentOwner.Email);
            Assert.AreEqual("Article's name", article.Name);
            Assert.AreEqual("Article's text", article.Text);
            Assert.AreEqual(0, article.Votings.Count());
        }
    }
}