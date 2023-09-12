using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Contracts
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category);
        Task<CatalogModel> GetCatalog(string id);
        Task<IEnumerable<CatalogModel>> GetCatalog();
    }
}
