using global::Domain.Abstractions;

namespace TadosBlog.Domain.Entities
{
    public class City : IEntity
    {
        protected internal City(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("City's name cannot be null or whitespace.", nameof(name));

            Name = name;
        }

        public City(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; init; }
    }
}
