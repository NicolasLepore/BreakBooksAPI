using AutoMapper;
using BreakBooks.Data.Dtos.BookDtos;
using BreakBooks.Data;
using BreakBooks.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using BreakBooks.Data.Dtos.LibrarySupplierDtos;

namespace BreakBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrarySupplierController : ControllerBase
    {
        private BooksContext _context;
        private IMapper _mapper;

        public LibrarySupplierController(BooksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateLibrarySupplierDto lsDto)
        {
            if (lsDto == null) return BadRequest();
            var ls = _mapper.Map<LibrarySupplier>(lsDto)!;

            _context.LibrarySuppliers.Add(ls);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ReadById), 
                new { libraryId = ls.LibraryId, supplierId = ls.SupplierId }, ls);
        }

        [HttpGet]
        public IActionResult Read([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var ls = _context.LibrarySuppliers.Skip(skip).Take(take).ToList();
            var mappedls = _mapper.Map<ICollection<ReadLibrarySupplierDto>>(ls);
            return Ok(mappedls);
        }

        [HttpGet("{libraryId}/{supplierId}")]
        public IActionResult ReadById(int libraryId, int supplierId)
        {
            var ls = _context.LibrarySuppliers.FirstOrDefault(ls => 
                ls.LibraryId == libraryId && ls.SupplierId == supplierId);

            if (ls == null) return NotFound();
            var mappedLs = _mapper.Map<ReadLibrarySupplierDto>(ls);
            return Ok(mappedLs);
        }

        [HttpPut("{libraryId}/{supplierId}")]
        public IActionResult Update(int libraryId, int supplierId, 
            [FromBody] UpdateLibrarySupplierDto lsDto)
        {
            var ls = _context.LibrarySuppliers.FirstOrDefault(ls => 
                ls.LibraryId == libraryId && ls.SupplierId == supplierId);
            if (ls == null) return NotFound();
            _mapper.Map(lsDto, ls);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{libraryId}/{supplierId}")]
        public IActionResult PartialUpdate(int libraryId, int supplierId, 
            [FromBody] JsonPatchDocument<UpdateLibrarySupplierDto> patch)
        {
            var ls = _context.LibrarySuppliers.FirstOrDefault(ls => 
                ls.LibraryId == libraryId && ls.SupplierId == supplierId);

            if(ls == null) return NotFound();
            var mappedLs = _mapper.Map<UpdateLibrarySupplierDto>(ls);

            patch.ApplyTo(mappedLs, ModelState);
            if(!TryValidateModel(mappedLs)) return ValidationProblem(ModelState);

            _mapper.Map(mappedLs, ls);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{libraryId}/{supplierId}")]
        public IActionResult Delete(int libraryId, int supplierId)
        {
            var ls = _context.LibrarySuppliers.FirstOrDefault(ls => 
                ls.LibraryId == libraryId && ls.SupplierId == supplierId);
            if (ls == null) return NotFound();

            _context.LibrarySuppliers.Remove(ls);
            _context.SaveChanges();

            return NoContent();
        }
    }
}