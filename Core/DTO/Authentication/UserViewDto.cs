﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Authentication
{
    public class UserViewDto
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;      
        public string Image { get; set; } = string.Empty;
        public bool LockoutEnabled { get; set; }=false;
        public DateTimeOffset? LockoutEnd { get; set; }
        public string Roles { get; set; }
    }
}
