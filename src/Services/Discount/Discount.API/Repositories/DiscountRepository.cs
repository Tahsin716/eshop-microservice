using Discount.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Repositories
{
    public class DiscountRepository
    {
        private readonly DiscountDbContext _context;

        public DiscountRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon> GetCoupon(string productName)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.ProductName == productName);

            return coupon ?? new Coupon
            {
                ProductName = "No Discount",
                Amount = 0,
                Description = string.Empty,
            };
        }
    }
}
