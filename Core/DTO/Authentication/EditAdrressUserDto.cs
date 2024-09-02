using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Authentication
{
    public class EditAdrressUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public int Country { get; set; }
        public string Town { get; set; }       
        public string Address { get; set; }
        public int? PostCode { get; set; }
    }
}
