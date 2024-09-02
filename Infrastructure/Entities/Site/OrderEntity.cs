using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{
    [Table("tblOrders")]
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public virtual OrderStatusEntity OrderStatus { get; set; }
        public DateTime DateCrated { get; set; }
        public virtual ICollection<OrderProductEntity> OrderProducts { get; set; }
        //Сума замовлення
        public int Amount { get; set; }
    }
}
