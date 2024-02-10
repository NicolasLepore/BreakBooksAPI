
﻿using AutoMapper;
using BreakBooks.Data;
using BreakBooks.Data.Dtos.CartDtos;
using BreakBooks.Models;
using Microsoft.AspNetCore.Identity;

namespace BreakBooks.Services
{
    public class CartService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly BooksContext _context;
        public CartService(SignInManager<User> signInManager, IMapper mapper, BooksContext context)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }

        internal ReadCartDto? GetCart(string username)
        {
            User? user = _signInManager.UserManager
                .Users.FirstOrDefault(u => u.UserName == username);

            Cart? cart = _context.Carts.FirstOrDefault(c => c.UserId == user.Id);

            var dto = _mapper.Map<ReadCartDto>(cart);

            return dto;
        }
    }
}