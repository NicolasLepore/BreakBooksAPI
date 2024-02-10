
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakBooks.Models
{
#nullable disable
    [Table("LibrarySupplier")]
    public class LibrarySupplier
    {
        public int LibraryId { get; set; }
        public int SupplierId { get; set; }
        public virtual Library Library { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}