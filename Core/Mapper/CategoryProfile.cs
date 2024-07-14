using AutoMapper;
using Core.DTO;
using Core.DTO.Site.Category;
using Core.DTO.Site.Product;
using Infrastructure.Entities.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, CategoryEntity>().ReverseMap();
            CreateMap<CreateCategoryDTO, CategoryEntity>().ReverseMap();
            CreateMap<EditCategoryDto, CategoryEntity>().ReverseMap();
        }
    }
}
