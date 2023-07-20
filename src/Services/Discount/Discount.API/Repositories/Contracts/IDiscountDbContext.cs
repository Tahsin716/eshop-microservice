using Discount.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Repositories.Contracts
{
    public interface IDiscountDbContext
    {
        DbSet<Coupon> Coupons { get; }
        Task SaveChangesAsync();
    }
}
