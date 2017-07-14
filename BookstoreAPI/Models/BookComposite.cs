
using System.Collections.Generic;

namespace BookstoreAPI.Models
{
    public class BookComposite
    {
        // Note: Using the Composite Design Pattern

        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishedMonth { get; set; }
        public int PublishedDay { get; set; }
        public int PublishedYear { get; set; }
        public string CoverImageUrl { get; set; }
        public Category[] Categories { get; set; }
        public BookHypermedia _Links { get; set; }

    }
}
