using Discount.API.Entities;

namespace Discount.API.Repositories.Contracts
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetCoupon(string productName);
        Task CreateCoupon(Coupon coupon);
        Task UpdateCoupon(Coupon coupon);
        Task DeleteCoupon(string productName);
    }
}
