﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Authentication
{
    public class RegisterResultDto
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; } = String.Empty;
    }
}
