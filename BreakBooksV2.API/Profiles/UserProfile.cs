
﻿using AutoMapper;
using BreakBooks.Data.Dtos.UserDtos;
using BreakBooks.Models;

namespace BreakBooks.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ReadUserDto>();
            CreateMap<CreateUserDto, User>();
        }
    }
}