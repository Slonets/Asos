using AutoMapper;
using Core.DTO.Site.Category;
using Core.DTO.Site.SubCategory;
using Infrastructure.Entities.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class SubCategoryProfile:Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategoryDto, SubCategoryEntity>().ReverseMap();
        }
    }
}
