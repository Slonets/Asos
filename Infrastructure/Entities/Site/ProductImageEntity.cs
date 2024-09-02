using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{

    public class ProductImageEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string ImagePath {  get; set; }
        [ForeignKey("Product")]
        public int ProductId {  get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
