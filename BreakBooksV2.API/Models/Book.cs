
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BreakBooks.Models
{
#nullable disable
    public class Book
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100)]
        
        public string Name { get; internal set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50)]
        public string Genre { get; internal set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public Int16 Pages { get; internal set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Price { get; internal set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int LibraryId { get; internal set; }
        public int CartId { get; internal set; }
        public virtual Library Library { get; internal set; }

        public virtual ICollection<CartBook> CartBooks { get; internal set; }
    }
}
