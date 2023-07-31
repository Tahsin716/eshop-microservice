using Discount.gRPC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Repositories
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> coupon { get; set; }
    }
}
