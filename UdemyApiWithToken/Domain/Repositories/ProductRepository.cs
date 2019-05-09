using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UdemyApiWithToken.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(UdemyApiWithTokenDBContext context) : base(context)
        {
        }

        public async Task AddProductAsync(Product product)
        {
            await context.Product.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int productId)
        {
            return await context.Product.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            var product = await FindByIdAsync(productId);

            context.Product.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            context.Product.Update(product);
        }
    }
}