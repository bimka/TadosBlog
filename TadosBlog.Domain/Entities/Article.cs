using TadosBlog.Domain.Enums;
using TadosBlog.Domain.ValueObjects;

namespace TadosBlog.Domain.Entities
{
    public class Article : Content
    {
        protected internal Article(User contentOwner, string name, string text)
            :base(contentOwner, ContentTypes.Article, name)
        {
            if (Enum.IsDefined(typeof(ContentTypes), 1))
                throw new ArgumentException(nameof(ContentTypes));

            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be null or whitespace.", nameof(text));

            Text = text;
        }
        public Article(long id, User contentOwner, string name, string text, IEnumerable<Voting> votings)
            : base(id, contentOwner, ContentTypes.Article, name, votings)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
