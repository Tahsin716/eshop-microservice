using Discount.gRPC.Entities;

namespace Discount.gRPC.Repositories.Contracts
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetCoupon(string productName);
        Task CreateCoupon(Coupon coupon);
        Task UpdateCoupon(Coupon coupon);
        Task DeleteCoupon(string productName);
    }
}
