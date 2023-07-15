using Catalog.API.Data.Contracts;
using Catalog.API.Entities;
using Catalog.API.Repositories.Contracts;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context
                           .Products
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }
    }
}
