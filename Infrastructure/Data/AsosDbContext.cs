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
        public DbSet<SubCategoryEntity> SubCategories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductImageEntity> ProductImages { get; set; }
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
                .HasMany(c=>c.SubCategories)
                .WithOne(s=>s.Category)
                .HasForeignKey(s=>s.CategoryId);

            builder.Entity<CategoryEntity>()
                .HasMany(c=>c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p=>p.CategoryId);

            builder.Entity<SubCategoryEntity>()
                .HasMany(s => s.Products)
                .WithOne(p => p.SubCategory)
                .HasForeignKey(p => p.SubCategoryId);

            builder.Entity<ProductEntity>()
                .HasMany(p=>p.productImages)
                .WithOne(pi=>pi.Product)
                .HasForeignKey(pi=>pi.ProductId);

            

        }
    }
}
