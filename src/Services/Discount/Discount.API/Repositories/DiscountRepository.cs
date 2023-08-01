using Discount.API.Data;
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
            var coupon = await _context.coupon
                .FirstOrDefaultAsync(x => x.productname == productName);

            return coupon ?? new Coupon
            {
                productname = productName,
                amount = 0,
                description = $"No Discount available for the product {productName}",
            };
        }

        public async Task<bool> CreateCoupon(Coupon coupon)
        {
            await _context.coupon.AddAsync(coupon);
            int dbEntries = await _context.SaveChangesAsync();
            return dbEntries > 0;
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            _context.coupon.Update(coupon);
            int dbEntries = await _context.SaveChangesAsync();
            return dbEntries > 0;
        }

        public async Task<bool> DeleteCoupon(string productName)
        {
            var coupon = await _context.coupon
                .FirstOrDefaultAsync(x => x.productname == productName);

            if (coupon != null)
            {
                _context.coupon.Remove(coupon);
                int dbEntries = await _context.SaveChangesAsync();
                return dbEntries > 0;
            }

            return false;
        }
    }
}
