using Discount.API.Entities;
using Discount.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountDbContext _context;

        public DiscountRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon> GetCoupon(string productName)
        {
            var coupon = await _context.Coupons
                .FirstOrDefaultAsync(x => x.ProductName == productName);

            return coupon ?? new Coupon
            {
                ProductName = productName,
                Amount = 0,
                Description = $"No Discount available for the product {productName}",
            };
        }

        public async Task CreateCoupon(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoupon(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoupon(string productName)
        {
            var coupon = await _context.Coupons
                .FirstOrDefaultAsync(x => x.ProductName == productName);
            
            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
