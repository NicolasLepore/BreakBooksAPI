
﻿using AutoMapper;
using BreakBooks.Data.Dtos.BookDtos;
using BreakBooks.Models;

namespace BreakBooks.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, ReadBookDto>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<Book, UpdateBookDto>();
        }
    }
}