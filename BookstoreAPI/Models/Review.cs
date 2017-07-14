using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace BookstoreAPI.Models
{
    public class Review
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public long BookID { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        public DateTime DatePublished { get; set; }

        // constructor
        //public Review(string reviewerName, string reviewText, int rating, DateTime datePublished)
        //{
        //    ReviewerName = reviewerName;
        //    ReviewText = reviewText;
        //    Rating = rating;
        //    DatePublished = datePublished;
        //}

    }
}
