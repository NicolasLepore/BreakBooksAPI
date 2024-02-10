using AutoMapper;
using BreakBooks.Data;
using BreakBooks.Data.Dtos.CartBookDto;
using BreakBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace BreakBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartBookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BooksContext _context;

        public CartBookController(IMapper mapper, BooksContext booksContext)
        {
            _mapper = mapper;
            _context = booksContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCartBookDto dto)
        {
            var cartBook = _mapper.Map<CartBook>(dto);
            _context.CartBooks.Add(cartBook);
            _context.SaveChanges();
            return Ok("Relação Criada");
        }
    }
}