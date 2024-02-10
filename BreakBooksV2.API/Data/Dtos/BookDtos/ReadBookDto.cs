
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BreakBooks.Models;
using BreakBooks.Data.Dtos.LibraryDtos;

namespace BreakBooks.Data.Dtos.BookDtos
{
#nullable disable
    public class ReadBookDto
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Genre { get; internal set; }
        public short Pages { get; internal set; }
        public double Price { get; internal set; }
        public int LibraryId { get; internal set; }
    }
}