using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Data
{
    public static class DiscountSeedContext
    {
        public static void Seed(DiscountDbContext context)
        {
            context.Database.Migrate();

            var dataExists = context.coupon.Any();

            if (!dataExists) 
            {
                context.coupon.AddRangeAsync(GetCoupons());
                context.SaveChangesAsync();
            }
        }

        private static IEnumerable<Coupon> GetCoupons()
        {
            return new List<Coupon>
            {
                new Coupon
                {
                    id = 1,
                    productname = "IPhone X",
                    description= "IPhone discount",
                    amount = 150
                },
                new Coupon
                {
                    id = 2,
                    productname = "Samsung Galaxy",
                    description = "Samsung Discount",
                    amount = 100
                }
            };
        }
    }
}
