using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Site.Basket
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }       
    }
}
