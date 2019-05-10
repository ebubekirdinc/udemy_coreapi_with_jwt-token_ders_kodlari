using System.Threading.Tasks;
using UdemyApiWithToken.Domain.Responses;

namespace UdemyApiWithToken.Domain.Services
{
    internal interface IProductService
    {
        Task<ProductListResponse> ListAsync();

        Task<ProductResponse> AddProduct(Product product);

        Task<ProductResponse> RemoveProduct(int productId);

        Task<ProductResponse> UpdateResponse(Product product, int productId);

        Task<Product> FindByIdAsync(int productId);
    }
}