using Discount.API.Entities;
using Discount.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Repositories
{
    public class DiscountDbContext : DbContext, IDiscountDbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        public async Task SaveChanges()
        {
            await base.SaveChangesAsync();
        }
    }
}
