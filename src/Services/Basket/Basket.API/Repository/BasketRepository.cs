using Basket.API.Entities;
using Basket.API.Repository.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;

        public BasketRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var stringifiedBasket = await _distributedCache.GetStringAsync(userName);

            var basket = string.IsNullOrEmpty(stringifiedBasket) 
                ? null
                : JsonConvert.DeserializeObject<ShoppingCart>(stringifiedBasket);

            return basket ?? new ShoppingCart(userName);
        }

        public async Task UpdateBasket(ShoppingCart basket)
        {
            await _distributedCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
        }

        public async Task DeleteBasket(string userName)
        {
            await _distributedCache.RemoveAsync(userName);
        }
    }
}
