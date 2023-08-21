using AutoMapper;
using Basket.API.Entities;
using EventBus.Messages.Events;

namespace Basket.API.Mappers
{
    public class BasketMapper : Profile
    {
        public BasketMapper()
        {
            CreateMap<BasketCheckoutEvent, BasketCheckout>();
        }
    }
}
