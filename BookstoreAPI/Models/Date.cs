using System;

namespace BookstoreAPI.Models
{

    public class Date
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }

        // constructor
        //public Date(int month, int day, int year)
        //{
        //    Month = month;
        //    Day = day;
        //    Year = year;
        //}

        // override ToString() method
        //public override string ToString()
        //{
        //    return String.Format("{0}/{1}/{2}", Month, Day, Year);
        //}

    }
}
