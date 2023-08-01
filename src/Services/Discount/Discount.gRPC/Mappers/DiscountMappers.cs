using AutoMapper;
using Discount.gRPC.Entities;
using Discount.gRPC.Protos;

namespace Discount.API.Mappers
{
    public class DiscountMappers : Profile
    {
        public DiscountMappers() 
        { 
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
