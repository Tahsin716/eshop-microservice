using Discount.gRPC.Protos;
using Discount.gRPC.Repositories.Contracts;
using Grpc.Core;

namespace Discount.gRPC.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(IDiscountRepository repository,
            ILogger<DiscountService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public override async Task<CouponModel> GetCoupon(GetCouponRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetCoupon(request.ProductName);

            if (coupon == null)
            {
                _logger.LogError($"Coupon for product {request.ProductName} not available");
                throw new RpcException(new Status(StatusCode.NotFound, $"Coupon for product {request.ProductName} is not available."));
            }

            return new CouponModel();
        }
    }
}
