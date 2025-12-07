using Matgr.ProductsAPI.Models.Dtos;

namespace Matgr.ProductsAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(int productId);

        Task<ProductDto> UpsertProduct(ProductDto productDto);

        Task<bool> DeleteProduct(int productId);
    }
}
