using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{
    [Table("tblOrderProducts")]
    public class OrderProductEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        //Кількість товару - 1, 2.
        public int Count { get; set; }
        //Ціна по якій було куплено товар
        public decimal Price { get; set; }
    }
}
