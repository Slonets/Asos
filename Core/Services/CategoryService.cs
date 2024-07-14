using AutoMapper;
using Core.DTO;
using Core.DTO.Site.Category;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;
using Infrastructure.Entities.Site;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly AsosDbContext _context;
        private readonly IRepository<CategoryEntity> _categoryRepository;

        public CategoryService(IRepository<CategoryEntity> categoryRepository, AsosDbContext context, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<CategoryEntity>(createCategoryDTO);
            await _categoryRepository.InsertAsync(category);
            await _categoryRepository.SaveAsync();
        }

        public async Task DeleteCategoryByIDAsync(int id)
        {
            var entity = await _categoryRepository.GetByIDAsync(id);
            if (entity != null)
            {
                await _categoryRepository.DeleteAsync(entity);
                await _categoryRepository.SaveAsync();
            }
        }

        public async Task EditAsync(EditCategoryDto editCategoryDTO)
        {
            var category = _mapper.Map<CategoryEntity>(editCategoryDTO);

            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveAsync();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIDAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var result = await _context.Category.ToListAsync();
            return _mapper.Map<List<CategoryDto>>(result);
        }
    }
}
