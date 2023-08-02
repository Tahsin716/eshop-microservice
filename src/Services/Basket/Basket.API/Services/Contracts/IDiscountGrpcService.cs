using Discount.gRPC.Protos;

namespace Basket.API.Services.Contracts
{
    public interface IDiscountGrpcService
    {
        Task<CouponModel> GetCoupon(string productName);
    }
}
