
﻿using System.ComponentModel.DataAnnotations;

namespace BreakBooks.Data.Dtos.UserDtos
{
#nullable disable
    public class CreateUserDto
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(30)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        [MaxLength(10)]
        public string Role { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}