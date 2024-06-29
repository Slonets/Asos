using AutoMapper;
using Core.DTO.Site.Category;
using Core.DTO.Site.SubCategory;
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
    public class SubCategoryService:ISubCategoryService
    {
        private readonly IMapper _mapper;
        private readonly AsosDbContext _context;
        public SubCategoryService( IMapper mapper, AsosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<SubCategoryDto>> GettAll()
        {
            var result = await _context.SubCategories.ToListAsync();
            return _mapper.Map<List<SubCategoryDto>>(result);

        }
    }
}
