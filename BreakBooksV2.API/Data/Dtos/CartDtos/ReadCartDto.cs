
﻿using BreakBooks.Data.Dtos.BookDtos;
using BreakBooks.Data.Dtos.CartBooksDto;
using BreakBooks.Data.Dtos.UserDtos;
using BreakBooks.Models;
using System.ComponentModel.DataAnnotations;

namespace BreakBooks.Data.Dtos.CartDtos
{
#nullable disable
    public class ReadCartDto
    {
        public int Id { get; internal set; }
        public ReadUserDto User { get; internal set; }
        public ICollection<ReadCartBookDto> CartBooks { get; internal set; }
    }
}