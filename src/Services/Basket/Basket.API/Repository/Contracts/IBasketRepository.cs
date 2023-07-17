using Basket.API.Entities;

namespace Basket.API.Repository.Contracts
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}
