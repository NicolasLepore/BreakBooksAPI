
﻿using AutoMapper;
using BreakBooks.Data.Dtos.LibraryDtos;
using BreakBooks.Models;

namespace BreakBooks.Profiles
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<CreateLibraryDto, Library>();
            CreateMap<UpdateLibraryDto, Library>();
            CreateMap<Library, UpdateLibraryDto>();
            CreateMap<Library, ReadLibraryDto>()
                .ForMember(l => l.Books, opt => 
                    opt.MapFrom(l => l.Books));

        }
    }
}