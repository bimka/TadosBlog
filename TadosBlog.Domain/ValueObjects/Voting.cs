using Domain.Abstractions;
using TadosBlog.Domain.Entities;

namespace TadosBlog.Domain.ValueObjects
{
    public class Voting : IValueObjectWithId
    {
        private readonly ISet<Voting> votings = new HashSet<Voting>();
        protected internal Voting(Content content, User user, int rating)
        {
            Content = content;
            User = user;
            Rating = rating;

            
        }

        public Voting(long id, Content content, User user, int rating)
            : this(content, user, rating)
        {
            Id = id;
        }
        public long Id { get; set; }
        public User User { get; init; }
        public Content Content { get; init; }
        public int Rating { get; init; }
        public IEnumerable<Voting> Votings { get { return votings; } }
    }
}
