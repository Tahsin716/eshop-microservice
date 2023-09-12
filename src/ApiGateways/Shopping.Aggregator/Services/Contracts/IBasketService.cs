using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Contracts
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string userName);
    }
}
