
﻿using AutoMapper;
using BreakBooks.Data.Dtos.CartDtos;
using BreakBooks.Models;

namespace BreakBooks.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CreateCartDto, Cart>();
            CreateMap<Cart, ReadCartDto>()
                .ForMember(dto => dto.User, 
                    opt => opt.MapFrom(cart => cart.User))
                .ForMember(dto => dto.CartBooks, 
                    opt => opt.MapFrom(cart => cart.CartBooks));
        }
    }
}