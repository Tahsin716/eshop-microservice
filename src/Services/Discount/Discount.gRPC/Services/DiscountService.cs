using AutoMapper;
using Discount.gRPC.Protos;
using Discount.gRPC.Repositories.Contracts;
using Grpc.Core;

namespace Discount.gRPC.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository,
            ILogger<DiscountService> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetCoupon(GetCouponRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetCoupon(request.ProductName);

            if (coupon == null)
            {
                _logger.LogError($"Coupon for product {request.ProductName} not available");
                throw new RpcException(new Status(StatusCode.NotFound, $"Coupon for product {request.ProductName} is not available."));
            }

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override Task<CreateCouponResponse> CreateCoupon(CreateCouponRequest request, ServerCallContext context)
        {
            return base.CreateCoupon(request, context);
        }

        public override Task<UpdateCouponResponse> UpdateCoupon(UpdateCouponRequest request, ServerCallContext context)
        {
            return base.UpdateCoupon(request, context);
        }

        public override Task<DeleteCouponResponse> DeleteCoupon(DeleteCouponRequest request, ServerCallContext context)
        {
            return base.DeleteCoupon(request, context);
        }
    }
}
