
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BreakBooks.Models
{
#nullable disable
    public class Library
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; internal set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50)]
        public string Name { get; internal set; }
 
        public int BooksAmount { get; internal set; } 

        public virtual ICollection<Book> Books { get; internal set; }
        
        public virtual ICollection<LibrarySupplier> LibrarySupplier { get; internal set; }
    }
}