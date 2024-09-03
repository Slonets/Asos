using AutoMapper;
using Core.DTO.Site.Category;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities.Site;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly AsosDbContext _context;

        public CategoryService(AsosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CreateCategoryDto model)
        {
            var category = _mapper.Map<CategoryEntity>(model);

            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryDto>> GettAll()
        {
            
                var result = await _context.Category.ToListAsync();
                return _mapper.Map<List<CategoryDto>>(result);
            
        }
    }
}
