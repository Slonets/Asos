﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Site
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<SubCategoryEntity> SubCategories { get; set; }
        public ICollection<ProductEntity> Products { get; set; }

    }
}