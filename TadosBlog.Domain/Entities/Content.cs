using Domain.Abstractions;
using System.Xml.Linq;
using TadosBlog.Domain.Enums;
using TadosBlog.Domain.ValueObjects;

namespace TadosBlog.Domain.Entities
{
    public abstract class Content : IEntity
    {
        private readonly ISet<Voting> _votings = new HashSet<Voting>();
        protected Content(User contentOwner, ContentTypes type, string name)
        {
            if (contentOwner == null)
                throw new ArgumentNullException(nameof(contentOwner));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Content name cannot be null or whitespace.", nameof(name));

            
            ContentOwner = contentOwner;
            Type = type;
            Name = name;
            AverageRating = 0;
        }

        public Content(long id, User contentOwner, ContentTypes type, string name, IEnumerable<Voting> votings)
            : this(contentOwner, type, name)
        {
            Id = id;

            foreach (var vote in votings)
            {
                _votings.Add(vote);
            }

            AverageRating = getAverageRating(_votings);
        }

        public long Id { get; set; }

        public User ContentOwner { get; init; }

        public ContentTypes Type { get; init; }

        public string Name { get; init; }

        public double AverageRating { get; set; }

        public IEnumerable<Voting> Votings => _votings;

        public void AddNewVote(Content content, User user, int rating)
        {
            _votings.Add(new Voting(content, user, rating));
        }

        private double getAverageRating(IEnumerable<Voting> _votings)
        {
            if (_votings.Count() == 0)
                return 0;        

            var ratinglist = _votings.Select(v => v.Rating).ToList();
                return Math.Round(ratinglist.Average(), 1, MidpointRounding.AwayFromZero);
        }
    }
}
