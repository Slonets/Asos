using AutoMapper;
using Core.DTO.Site.Brand;
using Core.DTO.Site.Category;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BrandServices : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly AsosDbContext _context;

        public BrandServices(IMapper mapper, AsosDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BrandDto>> GettAll()
        {
            var result = await _context.Brands.ToListAsync();
            return _mapper.Map<List<BrandDto>>(result);
        }


    }
}
