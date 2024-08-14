﻿using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Authentication
{
    public class EditUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }
        public string? Image { get; set; } = string.Empty;
    }

}
