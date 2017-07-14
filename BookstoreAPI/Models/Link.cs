

namespace BookstoreAPI.Models
{
    public class Link
    {

        public string Href { get; set; }

        // constructor
        public Link(string href)
        {
            Href = href;
        }

    }
}
