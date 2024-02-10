using AutoMapper;
using BreakBooks.Data;
using BreakBooks.Data.Dtos.LibraryDtos;
using BreakBooks.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BreakBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private BooksContext _context;
        private IMapper _mapper;

        public LibraryController(BooksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateLibrary([FromBody]CreateLibraryDto libraryDto)
        {
            var library = _mapper.Map<Library>(libraryDto);
            if(_context.Libraries.Any(l => l.Name == library.Name)) 
                return Conflict("This library already exists");

            _context.Libraries.Add(library);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReadLibraryById), new { id = library.Id}, library);
        }

        [HttpGet]
        public IActionResult ReadLibraries([FromQuery]int skip = 0, 
            [FromQuery]int take = 30)
        {
            var libraries = _context.Libraries.Skip(skip).Take(take).ToList();
            var librariesDto = _mapper.Map<List<ReadLibraryDto>>(libraries);

            foreach(var library in libraries) 
            {
                library.BooksAmount = library.Books.Count;
            }

            _context.SaveChanges();

            return Ok(librariesDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadLibraryById(int id, [FromQuery]int books = 5)
        {
            var library = _context.Libraries.FirstOrDefault(l => l.Id == id);
            if(library == null) return NotFound();

            library.BooksAmount = library.Books.Count;
            _context.SaveChanges();

            var libraryDto = _mapper.Map<ReadLibraryDto>(library);

            var bk = libraryDto.Books.Take(books).ToList();
            libraryDto.Books = bk;

            return Ok(libraryDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLibrary(int id, [FromBody]UpdateLibraryDto libraryDto)
        {
            var library = _context.Libraries.FirstOrDefault(l => l.Id == id);
            if(library == null) return NotFound();
            _mapper.Map(libraryDto, library);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateLibrary(int id, JsonPatchDocument<UpdateLibraryDto> patch)
        {
            var library = _context.Libraries.FirstOrDefault(l => l.Id == id);
            if (library == null) return NotFound();
            var mappedLibrary = _mapper.Map<UpdateLibraryDto>(library);

            patch.ApplyTo(mappedLibrary, ModelState);
            if (!TryValidateModel(mappedLibrary)) return ValidationProblem(ModelState);

            _mapper.Map(mappedLibrary, library);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLibrary(int id)
        {
            var library = _context.Libraries.FirstOrDefault(l => l.Id == id);
            if(library == null) return NotFound();
            _context.Libraries.Remove(library);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
