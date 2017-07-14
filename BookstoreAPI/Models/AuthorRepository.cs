using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreAPI.Models
{
    public class AuthorRepository : IAuthorRepository
    {

        private readonly BookstoreContext _context;

        public AuthorRepository(BookstoreContext context)
        {
            _context = context;

        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public void Add(Author item)
        {
            _context.Authors.Add(item);
            _context.SaveChanges();
        }

        public Author Find(long id)
        {
            return _context.Authors.FirstOrDefault(t => t.ID == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Authors.First(t => t.ID == id);
            _context.Authors.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Author item)
        {
            _context.Authors.Update(item);
            _context.SaveChanges();
        }
    }
}