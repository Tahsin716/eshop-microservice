﻿using Discount.gRPC.Entities;
using Discount.gRPC.Repositories;
using Discount.gRPC.Repositories.Contracts;
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

        public async Task CreateCoupon(Coupon coupon)
        {
            await _context.coupon.AddAsync(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoupon(Coupon coupon)
        {
            _context.coupon.Update(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoupon(string productName)
        {
            var coupon = await _context.coupon
                .FirstOrDefaultAsync(x => x.productname == productName);

            if (coupon != null)
            {
                _context.coupon.Remove(coupon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
