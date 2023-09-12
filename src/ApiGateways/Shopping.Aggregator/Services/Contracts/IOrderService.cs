using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
