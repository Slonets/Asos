using AutoMapper;
using Core.DTO.Site.Product;
using Infrastructure.Entities.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile() 
        {
            CreateMap<CreateProductDto,ProductEntity>().ReverseMap();
            CreateMap<GetAllProductDto,ProductEntity>().ReverseMap();
        }
    }
}
