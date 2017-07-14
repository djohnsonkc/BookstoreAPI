using System;
using System.Collections.Generic;
using System.Linq;


namespace BookstoreAPI.Models
{
    public class BookRepository : IBookRepository
    {

        private readonly BookstoreContext _context;

        public BookRepository(BookstoreContext context)
        {
            _context = context;

        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }



        public void Add(Book item)
        {
            _context.Books.Add(item);
            _context.SaveChanges();
        }

        public void AddAuthor(Author item)
        {
            _context.Authors.Add(item);
            _context.SaveChanges();
        }

        public void AddBookAuthor(BookAuthor item)
        {
            _context.BookAuthors.Add(item);
            _context.SaveChanges();

        }
        public Book Find(long id)
        {
            return _context.Books.FirstOrDefault(t => t.ID == id);
        }

        public BookComposite FindComposite(long bookID)
        {
            var book = _context.Books.FirstOrDefault(t => t.ID == bookID);

            //var authors = (from a in _context.Authors
            //               join ba in _context.BookAuthors on a.ID equals ba.AuthorID
            //               where ba.BookID == bookID
            //               select new
            //               {
            //                   a.FirstName,
            //                   a.LastName,
            //                   a.HeadshotImageUrl

            //               }).ToList();


            var authors = (from ba in _context.BookAuthors
                           join a in _context.Authors on ba.AuthorID equals a.ID
                           where ba.BookID == bookID
                           select a);

            //var reviews = (from r in _context.Reviews
            //               where r.BookID == bookID
            //               select r);

            BookComposite composite = new BookComposite();
            composite.Title = book.Title;
            composite.Description = book.Description;
            composite.PublishedMonth = book.PublishedMonth;
            composite.PublishedYear = book.PublishedYear;
            composite.PublishedDay = book.PublishedDay;
            composite._Links = new BookHypermedia();
            composite._Links.Self = new Link("http://localhost/books/" + book.ID);
            composite._Links.Reviews = new Link("http://localhost/books/" + book.ID + "/reviews");
            composite._Links.Authors = authors as IEnumerable<Author>;

            return composite;


            /*
      
            {
                "title":"Where the Red Fern Grows",
                "description":"Where the Red Fern Grows is a 1961 children's novel...",
                "publishedMonth":0,
                "publishedDay":0,
                "publishedYear":1961,
                "coverImageUrl":null,
                "categories":null,
                "_Links":{
                    "self":{
                        "href":"http://localhost/books/1"
                    },
                    "reviews":{
                        "href":"http://localhost/books/1/reviews"
                    },
                    "authors":[
                        {
                            "id":1,
                            "firstName":"Wilson",
                            "lastName":"Rawls",
                            "headshotImageUrl":"//via.placeholder.com/100x100"
                        },
                        {
                            "id":2,
                            "firstName":"Mark",
                            "lastName":"Twain",
                            "headshotImageUrl":"//via.placeholder.com/100x100"
                        }
                    ]
                }
            }
            
            */


        }

        //public IEnumerable<BookComposite> GetAllComposite()
        //{

        //    var book = _context.Books.FirstOrDefault(t => t.ID == id);
        //    var books = (from ba in _bookAuthorContext.BookAuthors
        //                   join b in _context.Books on ba.BookID equals b.ID
        //                   join a in _authorContext.Authors on ba.AuthorID equals a.ID

        //                   select new
        //                   {
        //                       Book = b,
        //                       Author = a,
        //                       ba = ba
        //                   }
        //    );

        //}

        public void Remove(long id)
        {
            var entity = _context.Books.First(t => t.ID == id);
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Book item)
        {
            _context.Books.Update(item);
            _context.SaveChanges();
        }
    }
}