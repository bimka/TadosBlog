using System.Text.RegularExpressions;
using TadosBlog.Domain.Enums;
using TadosBlog.Domain.ValueObjects;

namespace TadosBlog.Domain.Entities
{
    public class Video : Content
    {
        protected internal Video(User contentOwner, string name, string url)
            : base(contentOwner, ContentTypes.Video, name)
        {
            if (Enum.IsDefined(typeof(ContentTypes), 3))
                throw new ArgumentException(nameof(ContentTypes));

            if (!IsValidURL(url))
                throw new ArgumentException("URL is not valid!", nameof(url));

            Url = url;
        }
        public Video(long id, User contentOwner, string name, string url, IEnumerable<Voting> votings)
            : base(id, contentOwner, ContentTypes.Video, name, votings)
        {
            if (!IsValidURL(url))
                throw new ArgumentException("URL is not valid!", nameof(url));

            Url = url;
        }

        public string Url { get; set; }

        private bool IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
    }
}
