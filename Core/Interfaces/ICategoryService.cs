using Core.DTO;
using Core.DTO.Site.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDTO createCategoryDTO);
        Task DeleteCategoryByIDAsync(int id);
        Task EditAsync(EditCategoryDTO editCategoryDTO);
    }
}
