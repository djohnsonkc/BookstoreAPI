using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;

namespace BookstoreAPI.Models
{
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("ID")]
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishedMonth { get; set; }
        public int PublishedDay { get; set; }
        public int PublishedYear { get; set; }
        public string CoverImageUrl { get; set; }

    }
}
