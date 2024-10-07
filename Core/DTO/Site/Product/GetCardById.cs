using Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Site.Product
{
    public class GetCardById
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public string? Color { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public Gender Gender { get; set; }
        public string? SizeAndFit { get; set; }
        public string? LookAfterMe { get; set; }
        public string? AboutMe { get; set; }
        public int Amount { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}

