
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakBooks.Models
{
    public class Cart
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string? UserId { get; internal set; }
        public virtual User? User { get; internal set; }
        public virtual ICollection<CartBook>? CartBooks { get; internal set; }

    }
}