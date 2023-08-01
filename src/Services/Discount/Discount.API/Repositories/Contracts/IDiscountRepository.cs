using Discount.API.Entities;

namespace Discount.API.Repositories.Contracts
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetCoupon(string productName);
        Task<bool> CreateCoupon(Coupon coupon);
        Task<bool> UpdateCoupon(Coupon coupon);
        Task<bool> DeleteCoupon(string productName);
    }
}
