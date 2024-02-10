
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BreakBooks.Data.Dtos.LibrarySupplierDtos;

namespace BreakBooks.Data.Dtos.SupplierDtos
{
#nullable disable
    public class ReadSupplierDto
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Address { get; internal set; }
        public ICollection<ReadLibrarySupplierDto> LibrarySupplier { get; internal set; }
    }
}