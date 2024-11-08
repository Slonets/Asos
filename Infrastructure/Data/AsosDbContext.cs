﻿using Infrastructure.Entities;
using Infrastructure.Entities.Location;
using Infrastructure.Entities.Site;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AsosDbContext : IdentityDbContext<UserEntity, RoleEntity, int,
          IdentityUserClaim<int>, UserRoleEntity, IdentityUserLogin<int>,
          IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CountryEntity> Country { get; set; }
        public DbSet<TownEntity> Towns { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<ProductImageEntity> ProductImages { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderProductEntity> OrderProducts { get; set; }
        public DbSet<OrderStatusEntity> OrderStatus { get; set; }
        public DbSet<BasketEntity> Basket { get; set; }
        

        public AsosDbContext(DbContextOptions<AsosDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRoleEntity>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });
                ur.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(r => r.RoleId)
                    .IsRequired();
                ur.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(u => u.UserId)
                    .IsRequired();
            });
        }
    }
}
