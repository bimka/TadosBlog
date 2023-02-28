using global::Domain.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using TadosBlog.Domain.ValueObjects;

namespace TadosBlog.Domain.Entities
{
    public class User : IEntity
    {
        internal User(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));

            if (!EmailIsValid(email))
                throw new ArgumentException("Email is not valid!", nameof(email));

            Email = email;
        }

        public User(long id, string email)
        {
            Id = id;
            Email = email;
        }
        public long Id { get; set; }
        public string Email { get; init; }

        public void VoteFor(Content content, int rating)
        {
            if (rating <= 0 || rating > 5)
                throw new ArgumentOutOfRangeException(nameof(rating));

            var votedList = content.Votings.Select(v => v.User).ToList();

            if (!votedList.Contains(this))
            {
                content.AddNewVote(content, this, rating);     
            }
            else
                throw new ArgumentException("User cannot vote again!", nameof(this.Email));
        }

        private bool EmailIsValid(string email)
        {
            EmailAddressAttribute emailValidator = new EmailAddressAttribute();
            if (emailValidator.IsValid(email))
            {
                return true;
            }

            return false;
        }

    }
}
