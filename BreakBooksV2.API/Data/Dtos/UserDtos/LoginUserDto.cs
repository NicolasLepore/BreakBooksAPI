
﻿using System.ComponentModel.DataAnnotations;

namespace BreakBooks.Data.Dtos.UserDtos
{
#nullable disable
    public class LoginUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}