using AutoMapper;
using BreakBooks.Data;
using BreakBooks.Data.Dtos.CartDtos;
using BreakBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace BreakBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BooksContext _context;

        public CartController(IMapper mapper, BooksContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCartDto dto)
        {
            var cart = _mapper.Map<Cart>(dto);
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return Ok("Carrinho Criado!");
        }

    }
}