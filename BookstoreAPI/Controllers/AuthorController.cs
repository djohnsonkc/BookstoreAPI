using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookstoreAPI.Models;

namespace BookstoreAPI.Controllers
{
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _AuthorRepository;

        public AuthorController(IAuthorRepository AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }


        [HttpGet]
        public IEnumerable<Author> GetAll()
        {
            return _AuthorRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetById(long id)
        {
            var item = _AuthorRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Author item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _AuthorRepository.Add(item);

            return CreatedAtRoute("GetTodo", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Author item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var Author = _AuthorRepository.Find(id);
            if (Author == null)
            {
                return NotFound();
            }

            //Author.Description = item.Description;

            _AuthorRepository.Update(Author);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Author = _AuthorRepository.Find(id);
            if (Author == null)
            {
                return NotFound();
            }

            _AuthorRepository.Remove(id);
            return new NoContentResult();
        }


    }

}