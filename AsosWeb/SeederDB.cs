﻿using Core.Constants;
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Entities.Site;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities.Enums;

namespace AsosWeb
{
    public static class SeederDB
    {

        public static void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices
               .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AsosDbContext>();

                context.Database.Migrate();

                var userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<UserEntity>>();

                var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<RoleEntity>>();

                #region Seed Roles and Users

                if (!context.Roles.Any())
                {
                    foreach (var role in Roles.All)
                    {
                        var result = roleManager.CreateAsync(new RoleEntity
                        {
                            Name = role
                        }).Result;
                    }
                }

                if (!context.Users.Any())
                {
                    UserEntity user = new()
                    {
                        FirstName = "Гомер",
                        LastName = "Сімсон",
                        Email = "admin@gmail.com",
                        UserName = "admin@gmail.com"
                    };
                    var result = userManager.CreateAsync(user, "123456").Result;

                    if (result.Succeeded)
                    {
                        result = userManager.AddToRoleAsync(user, Roles.Admin).Result;
                    }
                    #endregion

                }
                #region Seed Brands, Categories, Subcategories, Products
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(
                         new BrandEntity { Name = "Nike" },
                         new BrandEntity { Name = "Adidas" },
                         new BrandEntity { Name = "Asos" }
                        );
                }
                if (!context.Category.Any())
                {
                    context.Category.AddRange(
                        new CategoryEntity { Name = "Clothing" },
                        new CategoryEntity { Name = "Sportswear" },
                        new CategoryEntity { Name = "Accessories" }
                        );
                }
                if (!context.SubCategories.Any())
                {
                    context.SubCategories.AddRange(
                        new SubCategoryEntity {Id=1, Name = "Shirts"  },
                        new SubCategoryEntity { Id = 2, Name = "Joggers" },
                        new SubCategoryEntity { Id = 3, Name = "Rings" }
                        );
                }
                //context.SaveChanges();
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                    new ProductEntity
                    {

                        Name = "Tommy Hilfiger pigment dyed solid regular fit shirt",
                        Description = "A basic, but make it elevated, Button-down collar, Button placket, Logo embroidery to chest, Regular fit",
                        Price = 50,
                        Size = Size.M,
                        Color = "green",
                        Gender = Gender.Male,
                        BrandId = 1,
                        CategoryId = 2,
                        SubCategoryId = 1,
                        SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Linen: lightweight and strong, Main: 100% Linen.",
                        
                        

                    },
                    new ProductEntity
                    {

                        Name = "adidas Football Entrada 22 joggers in black",
                        Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                        Price = 56,
                        Size = Size.L,
                        Color = "black",
                        Gender = Gender.Male,
                        BrandId = 2,
                        CategoryId = 3,
                        SubCategoryId = 2,
                        SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester.",
                        

                    },
                     new ProductEntity
                     {

                         Name = "ASOS DESIGN waterproof stainless steel band ring with greek wave edge in gold tone",
                         Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                         Price = 27,
                         Size = Size.L,
                         Color = "black",
                         Gender = Gender.Male,
                         BrandId = 3,
                         CategoryId = 1,
                         SubCategoryId = 3,
                         SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                         LookAfterMe = "Wipe clean with a soft dry cloth",
                         AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",
                         

                     }

                 );
                    context.SaveChanges();
                }
                #endregion
            }

        }
    }


}


