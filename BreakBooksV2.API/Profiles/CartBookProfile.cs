
﻿using AutoMapper;
using BreakBooks.Data.Dtos.CartBookDto;
using BreakBooks.Data.Dtos.CartBooksDto;
using BreakBooks.Models;

namespace BreakBooks.Profiles
{
    public class CartBookProfile : Profile
    {
        public CartBookProfile()
        {
            CreateMap<CreateCartBookDto, CartBook>();
            CreateMap<CartBook, ReadCartBookDto>()
                .ForMember(dto => dto.Book, 
                    opt => opt.MapFrom(cb => cb.Book));
        }
    }
}