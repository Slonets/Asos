using Core.DTO.Authentication;
using Core.DTO.Site.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task Create(CreateProductDto model);
        Task<bool> Delete(int id);
        Task<CreateProductDto> Get(int id);
        Task Update(UpdateProductDto model);
        Task<PagedResult<GetAllProductDto>> GetAllProducts(int pageNumber, int pageSize);
        List<object> GettAllSizes();
        List<object> GettAllGenders();
        Task<List<object>> GettAllSizesAsync();
        Task<List<object>> GettAllGendersAsync();
        Task<GetProductByIdDto> GetById(int id);
        Task<List<ViewManClothingDto>> GetManClothingAsync();
        Task<List<ViewManClothingDto>> GetWomanClothingAsync();
        Task<List<ViewManClothingDto>> GetArrayFavorite(int[] array);
        Task<bool> DeleteImageAsync(string imagePath);
        Task AddProductImages(int productId, List<IFormFile> images);

        Task <int>ReturnNewProductSize(string nameProduct, int newSize);
    }
}
