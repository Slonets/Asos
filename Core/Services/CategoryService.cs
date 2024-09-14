using AutoMapper;
using Core.DTO.Authentication;
using Core.DTO.Site.Category;
using Core.DTO.Site.Product;
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

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<List<CategoryDto>> GettAll()
        {

            var result = await _context.Category.ToListAsync();
            return _mapper.Map<List<CategoryDto>>(result);

        }
        public async Task<PagedResult<CategoryDto>> GetAllPageCategories(int pageNumber, int pageSize)
        {
            var query = _context.Category;

            // Загальна кількість категорій
            var totalCategories = await query.CountAsync();

            // Повернення категорій для конкретної сторінки
            var categories = await query
                .Skip((pageNumber - 1) * pageSize)  // Пропустити категорії для попередніх сторінок
                .Take(pageSize)  // Вибрати категорії для поточної сторінки
                .ToListAsync();

            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            return new PagedResult<CategoryDto>
            {
                Items = categoryDtos,
                TotalCount = totalCategories,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
        }
    }
}
