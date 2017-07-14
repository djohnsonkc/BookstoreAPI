using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookstoreAPI.Models;

namespace BookstoreAPI.Controllers
{
    [Route("api/bookauthors")]
    public class BookAuthorsController : Controller
    {

        private readonly IBookAuthorRepository _bookAuthorRepository;


        public BookAuthorsController(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }


        [HttpGet]
        public IEnumerable<BookAuthor> GetAll()
        {
            return _bookAuthorRepository.GetAll();
        }


        [HttpGet("{id}", Name = "GetBookAuthors")]
        public IEnumerable<Author> GetById(long id)
        {
            return _bookAuthorRepository.GetAuthorsByBookID(id);
        }



    }
}
