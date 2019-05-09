using System.Collections.Generic;
using System.Threading.Tasks;

namespace UdemyApiWithToken.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();

        Task AddProductAsync(Product product);

        Task RemoveProductAsync(int productId);

        Task UpdateProductAsync(Product product);

        Task<Product> FindByIdAsync(int productId);
    }
}