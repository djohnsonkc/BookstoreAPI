using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookstoreAPI.Models;

namespace BookstoreAPI.Controllers
{
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;


        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
 

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetById(long id)
        {
            var item = _bookRepository.FindComposite(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Book item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _bookRepository.Add(item);

            return CreatedAtRoute("GetTodo", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Book item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var book = _bookRepository.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Description = item.Description;

            _bookRepository.Update(book);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookRepository.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Remove(id);
            return new NoContentResult();
        }


    }

}
