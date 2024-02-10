using BreakBooks.Models;
using System.ComponentModel.DataAnnotations;

namespace BreakBooks.Data.Dtos.CartBookDto
{
    public class CreateCartBookDto
    {
        [Required]
        public int CartId { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}
