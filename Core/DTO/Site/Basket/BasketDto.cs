using Infrastructure.Entities.Site;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Site.Basket
{
    public class BasketDto
    {
        public int Id { get; set; }        
        public int? UserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; } = 1;
        public DateTime DateAdded { get; set; }
    }
}
