using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{
    public class BasketEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; } // Може бути NULL для неавторизованого користувача

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        // Кількість товарів в кошику
        public int Count { get; set; }        

        // Дата додавання до кошика
        public DateTime DateAdded { get; set; }
    }
}
