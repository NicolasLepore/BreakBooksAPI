
﻿using AutoMapper;
using BreakBooks.Data.Dtos.LibrarySupplierDtos;
using BreakBooks.Models;

namespace BreakBooks.Profiles
{
    public class LibrarySupplierProfile : Profile
    {

        public LibrarySupplierProfile()
        {
            CreateMap<CreateLibrarySupplierDto, LibrarySupplier>();
            CreateMap<UpdateLibrarySupplierDto, LibrarySupplier>();
            CreateMap<LibrarySupplier, UpdateLibrarySupplierDto>();
            CreateMap<LibrarySupplier, ReadLibrarySupplierDto>();

        }
    }
}

