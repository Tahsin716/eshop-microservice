using AutoMapper;
using Ordering.Application.Features.Orders.Queries.GetOrderList;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings
{
    public class OrderMappers : Profile
    {
        public OrderMappers()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
