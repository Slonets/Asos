using Core.DTO.Site.Product;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task Create(CreateProductDto model);
        Task<bool> Delete(int id);
        Task<CreateProductDto> Get(int id);
        Task Update(UpdateProductDto model);
        Task<List<GetAllProductDto>> GettAll();
        List<object> GettAllSizes();
        List<object> GettAllGenders();
        Task<List<object>> GettAllSizesAsync();
        Task<List<object>> GettAllGendersAsync();
        Task<GetProductByIdDto> GetById(int id);
        Task<List<ViewManClothingDto>> GetManClothingAsync();
        Task<List<ViewManClothingDto>> GetWomanClothingAsync();

        Task<List<ViewManClothingDto>> GetArrayFavorite(int[] array);
    }
}
