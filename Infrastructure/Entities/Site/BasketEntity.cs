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
        public int? UserId { get; set; }
        public UserEntity User { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int Count { get; set; } = 1;      
        public DateTime DateAdded { get; set; }
    }
}
