
﻿using AutoMapper;
using BreakBooks.Data.Dtos.SupplierDtos;
using BreakBooks.Models;

namespace BreakBooks.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<Supplier, ReadSupplierDto>();
            CreateMap<Supplier, UpdateSupplierDto>();
            CreateMap<UpdateSupplierDto, Supplier>();
        }
    }
}
