using System.Collections.Generic;

namespace BookstoreAPI.Models
{
    public interface IBookAuthorRepository
    {
        void Add(BookAuthor item);
        IEnumerable<BookAuthor> GetAll();
        IEnumerable<Author> GetAuthorsByBookID(long bookID);
        BookAuthor Find(long bookID, long authorID);
        void Remove(long bookID, long authorID);

    }
}