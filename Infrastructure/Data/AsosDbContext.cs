using Infrastructure.Entities;
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
        public DbSet<ProductImageEntity> ProductImages { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
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

            builder.Entity<BrandEntity>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId);

        

            builder.Entity<CategoryEntity>()
                .HasMany(c=>c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p=>p.CategoryId);


            builder.Entity<ProductEntity>()
                .HasMany(p=>p.productImages)
                .WithOne(pi=>pi.Product)
                .HasForeignKey(pi=>pi.ProductId);

        }
    }
}
