using BreakBooks.Data.Dtos.BookDtos;
using BreakBooks.Data.Dtos.LibrarySupplierDtos;
using BreakBooks.Models;

namespace BreakBooks.Data.Dtos.LibraryDtos
{
#nullable disable
    public class ReadLibraryDto
    {
        public string Name { get; internal set; }
        public int Id { get; internal set; }
        public int BooksAmount { get; internal set; } 
        public ICollection<ReadBookDto> Books { get; internal set; }
        public ICollection<ReadLibrarySupplierDto> LibrarySupplier { get; internal set; }
    }
}