using Core.DTO.Site.Category;
using Core.DTO.Site.Product;
using Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task Create(CreateProductDto model);
        Task Delete(int id);
        Task<CreateProductDto> Get(int id);
        List<object> GettAllSizes();
        List<object> GettAllGenders();
        Task<List<object>> GettAllSizesAsync();
        Task<List<object>> GettAllGendersAsync();
    }
}
