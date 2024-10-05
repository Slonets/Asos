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
    public class GetProductByIdDto
    {
        public int Id { get; set; }       
        public string? Name { get; set; }
        public string? Description { get; set; }        
        public decimal Price { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public string? Gender { get; set; }
        public string? SizeAndFit { get; set; }
        public string? LookAfterMe { get; set; }
        public string? AboutMe { get; set; }
        public int Amount { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
