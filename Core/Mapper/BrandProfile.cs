using AutoMapper;
using Core.DTO.Site.Brand;
using Core.DTO.Site.Category;
using Infrastructure.Entities.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandDto, BrandEntity>().ReverseMap();
        }
    }
}
