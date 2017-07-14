using System.Collections.Generic;

namespace BookstoreAPI.Models
{
    public interface IReviewRepository
    {
        void Add(Review item);
        IEnumerable<Review> GetAll();
        Review Find(long id);
        void Remove(long id);
        void Update(Review item);
    }
}