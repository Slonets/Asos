using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Authentication
{
    public class LoginResultDto
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
    }
}
