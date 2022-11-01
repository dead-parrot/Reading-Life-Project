using Microsoft.AspNetCore.Mvc;
using ReadingLifeProject.Data;
using ReadingLifeProject.Data.DTOs;
using ReadingLifeProject.Models;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace ReadingLifeProject.Controllers
{
    [ApiController]
    [Route("livros")]
    public class ReadingLifeController:ControllerBase
    {
        private ReadingContext _context;
        
        public ReadingLifeController(ReadingContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostBook([FromBody] CreateBookDTO bookDTO)
        {
            Book book = new Book
            {
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Publisher = bookDTO.Publisher
            };

            _context.books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBookById), new {id = book.Id}, book);
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks(){
            return _context.books;
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            Book book = _context.books.FirstOrDefault<Book>(Book => Book.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookDTO BookDTO) {
            Book book = _context.books.FirstOrDefault(Book => Book.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            book.Title = BookDTO.Title;
            book.Author = BookDTO.Author;
            book.Publisher = BookDTO.Publisher;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
