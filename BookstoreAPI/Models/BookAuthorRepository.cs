using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreAPI.Models
{
    public class BookAuthorRepository : IBookAuthorRepository
    {

        private readonly BookstoreContext _context;

        public BookAuthorRepository(BookstoreContext context)
        {
            _context = context;

        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return _context.BookAuthors.ToList();
        }

        public IEnumerable<Author> GetAuthorsByBookID(long bookID)
        {

            //var authors = (from t in _context.BookAuthors where t.ID == bookID select t

            var authors = (from ba in _context.BookAuthors
                           join a in _context.Authors on ba.AuthorID equals a.ID
                           where ba.BookID == bookID
                           select a );


            return authors;
        }

        public void Add(BookAuthor item)
        {
            _context.BookAuthors.Add(item);
            _context.SaveChanges();
        }

        public BookAuthor Find(long bookID, long authorID)
        {
            return _context.BookAuthors.FirstOrDefault(t => t.BookID == bookID && t.AuthorID == authorID);
        }

        public void Remove(long bookID, long authorID)
        {
            var entity = _context.BookAuthors.First(t => t.BookID == bookID && t.AuthorID == authorID);
            _context.BookAuthors.Remove(entity);
            _context.SaveChanges();
        }


    }
}