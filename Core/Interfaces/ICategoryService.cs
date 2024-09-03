using Core.DTO.Site.Category;
using Core.DTO.Site.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GettAll();
        Task Create(CreateCategoryDto model);
        Task<bool> Delete(int id);
    }
}
