using AutoMapper;
using BreakBooks.Data;
using BreakBooks.Data.Dtos.BookDtos;
using BreakBooks.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace BreakBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private BooksContext _context;
        private IMapper _mapper;

        public BookController(BooksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult CreateBook([FromBody] CreateBookDto bookDto)
        {
            if (bookDto == null) return BadRequest();
            Book book = _mapper.Map<Book>(bookDto)!;

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ReadBooksById), new { id = book.Id }, book);
        }

        [HttpGet]
        public IActionResult ReadBooks([FromQuery] int skip = 0, [FromQuery] int take = 3)
        {
            var books = _context.Books.Skip(skip).Take(take).ToList();
            var mappedBooks = _mapper.Map<ICollection<ReadBookDto>>(books);
            return Ok(mappedBooks);
        }

        [HttpGet("{id}")]
        public IActionResult ReadBooksById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if(book == null) return NotFound(); 
            var mappedBook = _mapper.Map<ReadBookDto>(book);
            return Ok(mappedBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookDto bookDto)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if(book == null) return NotFound();
            _mapper.Map(bookDto, book);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateBook(int id, 
            [FromBody]JsonPatchDocument<UpdateBookDto> patch)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if(book == null) return NotFound();
            var target = _mapper.Map<UpdateBookDto>(book);

            patch.ApplyTo(target, ModelState);
            if (!TryValidateModel(target)) return ValidationProblem(ModelState);

            _mapper.Map(target, book);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if(book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}