using Core.DTO.Site.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Authentication
{
    public class LoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<int> Baskets { get; set; } = new List<int>();
        public List<OrderItemDto>? Orders { get; set; }
    }
}
