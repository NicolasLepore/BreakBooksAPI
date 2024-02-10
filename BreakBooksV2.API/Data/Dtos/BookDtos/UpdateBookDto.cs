
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BreakBooks.Data.Dtos.BookDtos
{
#nullable disable
    public class UpdateBookDto
    {

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100)]

        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public short Pages { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int LibraryId { get; set; }
    }
}