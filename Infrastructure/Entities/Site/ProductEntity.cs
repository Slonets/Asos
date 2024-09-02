using Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{
    public class ProductEntity
    {
        public int Id { get; set; }
        [Required, StringLength(500)]
        public string Name { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public string Color { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual BrandEntity Brand { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public Gender Gender { get; set; }
        public string LookAfterMe { get; set; }
        public string AboutMe { get; set; }
        public string SizeAndFit { get; set; }
        public int Amount {  get; set; }
        public virtual ICollection<ProductImageEntity> ProductImages { get; set; }

        public virtual ICollection<OrderProductEntity> OrderProducts { get; set; }
    }
}
