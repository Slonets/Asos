using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{
    public class ProductImageEntity
    {
        public int Id { get; set; }
        [Required]
        public string ImagePath {  get; set; }
        public int ProductId {  get; set; }
        public ProductEntity Product { get; set; }
    }
}
