using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public int Amount { get; set; }
    }
}
