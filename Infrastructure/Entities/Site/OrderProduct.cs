using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Orders Order { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
