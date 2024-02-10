using AutoMapper;
using BreakBooks.Data.Dtos.UserDtos;
using BreakBooks.Models;
using BreakBooks.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BreakBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserServices _userServices;
        private readonly CartService _cartService;

        public UserController(IMapper mapper, UserServices userServices, CartService cartService)
        {
            _userServices = userServices;
            _mapper = mapper;
            _cartService = cartService;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);

            await _userServices.Register(user, dto);

            return Ok("Usuario Criado");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginUserDto dto)
        {
            var token = await _userServices.SignIn(dto);
            
            return Ok(token);
        }

        [Authorize]
        [HttpGet("{username}/cart")]
        public IActionResult GetCart(string username)
        {
            string? claim = User.FindFirst(claim => claim.Type == ClaimTypes.Name)?.Value;
            if(claim == null || claim != username) return Forbid();

            var cart = _cartService.GetCart(username);
            if(cart == null) return NotFound("Usuario nao encontrado");

            return Ok(cart);
        }
    }
}