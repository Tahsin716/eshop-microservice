using Basket.API.Services.Contracts;
using Discount.gRPC.Protos;

namespace Basket.API.Services
{
    public class DiscountGrpcService : IDiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }

        public async Task<CouponModel> GetCoupon(string productName)
        {
            var discountRequest = new GetCouponRequest { ProductName = productName };
            return await _discountProtoService.GetCouponAsync(discountRequest);
        }
    }
}
