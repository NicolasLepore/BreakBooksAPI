
﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BreakBooks.Models
{
#nullable disable
    public class User : IdentityUser
    {
        public User() : base() 
        {
            
        }
        public DateTime Birthday { get; set; }
        public RoleType Role { get; set; }
        public virtual Cart Cart { get; set; }
        public enum RoleType
        {
            User,
            Admin
        }
    }  
}