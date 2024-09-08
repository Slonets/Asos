using Infrastructure.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Site.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public string Color { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        // public int SubCategoryId { get; set; }
        public Gender Gender { get; set; }
        public string SizeAndFit { get; set; }
        public string LookAfterMe { get; set; }
        public string AboutMe { get; set; }
        public int Amount { get; set; }
        public ICollection<IFormFile> ImageUrls { get; set; }
    }
}
