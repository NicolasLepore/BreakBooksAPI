
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakBooks.Models
{
#nullable disable
    public class Supplier
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; internal set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; internal set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; internal set; }

        public virtual ICollection<LibrarySupplier> LibrarySupplier { get; internal set; }
    }
}