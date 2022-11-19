using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using ReadingLifeProject.Data;
using ReadingLifeProject.Data.DTOs;
using ReadingLifeProject.Models;
using System;
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
                Publisher = bookDTO.Publisher,
                Date = DateTime.Now,
                Category = bookDTO.Category == null ? Category.Outros : bookDTO.Category,
                Review = bookDTO.Review
            };

            _context.books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBookById), new {id = book.Id}, book);
        }

        [HttpGet]
        public IActionResult GetBooks([FromQuery] string review=""){
            
            if (String.IsNullOrEmpty(review)){
                return Ok(_context.books);
            }

            IEnumerable<Book> booksFound = _context.books.Where<Book>(Book => Book.Review.Contains(review));

            if(booksFound == null)
            {
                return BadRequest($"Não há reviews com a palavra {review}");
            }

            return Ok(booksFound);
            
        }

        [HttpGet("resumo/{ano}/{mes}")]
        public IActionResult GetSummaryOfBooks(int ano, int mes)
        {
            IEnumerable<Book> booksFound =  _context.books.Where<Book>(Book => Book.Date.Year == ano && Book.Date.Month == mes);
            if (booksFound == null)
            {
                return BadRequest($"Não há registro de leituras para {mes}/{ano}");
            }
            return Ok(booksFound);
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
