using System.Collections.Generic;

namespace BookstoreAPI.Models
{
    public interface ICategoryRepository
    {
        void Add(Category item);
        IEnumerable<Category> GetAll();
        Category Find(long id);
        void Remove(long id);
        void Update(Category item);
    }
}