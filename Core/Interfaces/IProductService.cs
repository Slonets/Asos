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
        Task<PagedResult<GetAllProductDto>> GetAllProductsForAdmin(int pageNumber, int pageSize);
        Task<PagedResult<ViewAllManClothingDto>> GetAllManClothingAsync(int pageNumber, int pageSize);
        Task<PagedResult<ViewAllWomanClothingDto>> GetAllWomanClothingAsync(int pageNumber, int pageSize);
        Task<PagedResult<GetAllProductDto>> GetAllMakeUp(int pageNumber, int pageSize);
        Task<PagedResult<GetAllProductDto>> GetAllSkinCare(int pageNumber, int pageSize);
        Task<PagedResult<GetAllProductDto>> GetAllHairCare(int pageNumber, int pageSize);
        Task<PagedResult<GetAllProductDto>> GetAllPerfume(int pageNumber, int pageSize);
        Task<List<GetProductByIdDto>> GetAllPerfumeWithoutPagination();
        Task<List<GetProductByIdDto>> GetAllMakeUpWithoutPagination();
        Task<List<GetProductByIdDto>> GetAllSkinCareWithoutPagination();
        List<object> GettAllSizes();
        List<object> GettAllGenders();
        Task<List<object>> GettAllSizesAsync();
        Task<List<object>> GettAllGendersAsync();
        Task<GetProductByIdDto> GetById(int id);
        Task<GetCardById> GetByIdCard(int id);
        Task<List<ViewManClothingDto>> GetManClothingAsync();
        Task<List<ViewManClothingDto>> GetWomanClothingAsync();
        Task<List<ViewManClothingDto>> GetArrayFavorite(int[] array);
        Task<bool> DeleteImageAsync(string imagePath);
        Task AddProductImages(int productId, List<IFormFile> images);
        Task <int>ReturnNewProductSize(string nameProduct, int newSize);
        Task<List<GetProductByIdDto>> SearchProducts(string name);
    }
}
