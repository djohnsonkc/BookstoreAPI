using System.Collections.Generic;

namespace BookstoreAPI.Models
{
    public class BookHypermedia
    {
        public Link Self { get; set; }
        public Link Reviews { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
