﻿using Discount.API.Entities;
using Discount.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Repositories
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> coupon { get; set; }
    }
}
