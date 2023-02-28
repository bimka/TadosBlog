using global::Domain.Abstractions;

namespace TadosBlog.Domain.Entities
{
    public class Country : IEntity
    {
        protected internal Country(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Country's name cannot be null or whitespace.", nameof(name));

            Name = name;
        }

        public Country(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; init; }
    }
}
