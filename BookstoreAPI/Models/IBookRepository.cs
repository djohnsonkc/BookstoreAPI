using System.Collections.Generic;

namespace BookstoreAPI.Models
{
    public interface IBookRepository
    {
        void Add(Book item);
        IEnumerable<Book> GetAll();
        //IEnumerable<BookComposite> GetAllComposite(); // experimental
        Book Find(long id);
        BookComposite FindComposite(long bookID);
        void Remove(long id);
        void Update(Book item);
    }
}