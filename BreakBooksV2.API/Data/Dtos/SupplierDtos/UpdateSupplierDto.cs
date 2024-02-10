
﻿using System.ComponentModel.DataAnnotations;

namespace BreakBooks.Data.Dtos.SupplierDtos
{
#nullable disable
    public class UpdateSupplierDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
