using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BreakBooks.Data.Dtos.LibraryDtos
{
#nullable disable
    public class CreateLibraryDto
    { 
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}