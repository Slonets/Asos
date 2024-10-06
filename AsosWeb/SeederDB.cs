using Core.Constants;
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Entities.Site;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities.Enums;
using Infrastructure.Entities.Location;
using System;
using Core.Interfaces;
using System.Threading.Channels;

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

                var service = scope.ServiceProvider;

                var imageWorker = service.GetRequiredService<IFotoAvatar>();

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

                    UserEntity user2 = new()
                    {
                        FirstName = "Губка",
                        LastName = "Боб",
                        Email = "admin2@gmail.com",
                        UserName = "admin2@gmail.com"
                    };
                    var result2 = userManager.CreateAsync(user2, "123456").Result;

                    if (result2.Succeeded)
                    {
                        result2 = userManager.AddToRoleAsync(user2, Roles.User).Result;
                    }

                    UserEntity user3 = new()
                    {
                        FirstName = "Міні",
                        LastName = "піг",
                        Email = "admin3@gmail.com",
                        UserName = "admin3@gmail.com"
                    };
                    var result3 = userManager.CreateAsync(user3, "123456").Result;

                    if (result3.Succeeded)
                    {
                        result3 = userManager.AddToRoleAsync(user3, Roles.User).Result;
                    }

                    UserEntity user4 = new()
                    {
                        FirstName = "Том",
                        LastName = "і Джері",
                        Email = "admin4@gmail.com",
                        UserName = "admin4@gmail.com"
                    };
                    var result4 = userManager.CreateAsync(user4, "123456").Result;

                    if (result4.Succeeded)
                    {
                        result4 = userManager.AddToRoleAsync(user4, Roles.User).Result;
                    }

                    UserEntity user5 = new()
                    {
                        FirstName = "Том",
                        LastName = "Редл",
                        Email = "admin5@gmail.com",
                        UserName = "admin5@gmail.com"
                    };
                    var result5 = userManager.CreateAsync(user5, "123456").Result;

                    if (result5.Succeeded)
                    {
                        result5 = userManager.AddToRoleAsync(user5, Roles.User).Result;
                    }


                    UserEntity user6 = new()
                    {
                        FirstName = "Альбус",
                        LastName = "Дамбелдор",
                        Email = "admin6@gmail.com",
                        UserName = "admin6@gmail.com"
                    };
                    var result6 = userManager.CreateAsync(user6, "123456").Result;

                    if (result6.Succeeded)
                    {
                        result6 = userManager.AddToRoleAsync(user6, Roles.User).Result;
                    }

                    UserEntity user7 = new()
                    {
                        FirstName = "Гаррі",
                        LastName = "Поттер",
                        Email = "admin7@gmail.com",
                        UserName = "admin7@gmail.com"
                    };
                    var result7 = userManager.CreateAsync(user7, "123456").Result;

                    if (result7.Succeeded)
                    {
                        result7 = userManager.AddToRoleAsync(user7, Roles.User).Result;
                    }

                    UserEntity user8 = new()
                    {
                        FirstName = "Герміона",
                        LastName = "Ґрейнджер",
                        Email = "admin8@gmail.com",
                        UserName = "admin8@gmail.com"
                    };
                    var result8 = userManager.CreateAsync(user8, "123456").Result;

                    if (result8.Succeeded)
                    {
                        result8 = userManager.AddToRoleAsync(user8, Roles.User).Result;
                    }

                    UserEntity user9 = new()
                    {
                        FirstName = "Вейлон",
                        LastName = "Смізерс",
                        Email = "admin9@gmail.com",
                        UserName = "admin9@gmail.com"
                    };
                    var result9 = userManager.CreateAsync(user9, "123456").Result;

                    if (result9.Succeeded)
                    {
                        result9 = userManager.AddToRoleAsync(user9, Roles.User).Result;
                    }

                    UserEntity user10 = new()
                    {
                        FirstName = "Монтгомері",
                        LastName = "Бернс",
                        Email = "admin10@gmail.com",
                        UserName = "admin10@gmail.com"
                    };
                    var result10 = userManager.CreateAsync(user10, "123456").Result;

                    if (result10.Succeeded)
                    {
                        result10 = userManager.AddToRoleAsync(user10, Roles.User).Result;
                    }
                }
                #endregion


                #region Seed Brands, Categories, Products

                if (!context.Brands.Any())
                {
                    var nike = new BrandEntity { Name = "Nike" };
                    var adidas = new BrandEntity { Name = "Adidas" };
                    var asos = new BrandEntity { Name = "Asos" };
                    var gucci = new BrandEntity { Name = "Gucci" };
                    var prada = new BrandEntity { Name = "Prada" };
                    var chanel = new BrandEntity { Name = "Chanel" };
                    var burberry = new BrandEntity { Name = "Burberry " };
                    context.Brands.AddRange([nike, adidas, asos, gucci, prada, chanel, burberry]);

                    var clothing = new CategoryEntity { Name = "Clothing" };
                    var sportswear = new CategoryEntity { Name = "Sportswear" };
                    var accessories = new CategoryEntity { Name = "Accessories" };
                    var makeup = new CategoryEntity { Name = "Make Up" };
                    var skincare = new CategoryEntity { Name = "Skin Care" };
                    var haircare = new CategoryEntity { Name = "Hair Care" };
                    var perfume = new CategoryEntity { Name = "Perfume" };

                    context.Category.AddRange([clothing, sportswear, accessories, makeup, skincare, haircare, perfume]);

                    context.Products.AddRange(
                    new ProductEntity
                    {

                        Name = "Tommy Hilfiger pigment dyed solid regular fit shirt",
                        Description = "A basic, but make it elevated, Button-down collar, Button placket, Logo embroidery to chest, Regular fit",
                        Price = 50,
                        Size = Size.XS,
                        Color = "green",
                        Gender = Gender.Male,
                        Brand = nike,
                        Category = sportswear,
                        SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Linen: lightweight and strong, Main: 100% Linen.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            { 
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/36/3f/e67896c1b9380265335659f7fd42.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }, 
                            new ProductImageEntity
                            { 
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/16/94/5180ba5e67b72fd85c33a140dcef.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }, 
                            new ProductImageEntity
                            { 
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/15/db/c0b81c8877b5bd04892b9a578b26.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }, 
                            new ProductImageEntity
                            { 
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/fe/6e/e0d12cf0cd7766233da8bc70c0b8.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }
                        }
                },
                    new ProductEntity
                    {

                        Name = "Tommy Hilfiger pigment dyed solid regular fit shirt",
                        Description = "A basic, but make it elevated, Button-down collar, Button placket, Logo embroidery to chest, Regular fit",
                        Price = 50,
                        Size = Size.S,
                        Color = "green",
                        Gender = Gender.Male,
                        Brand = nike,
                        Category = sportswear,
                        SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Linen: lightweight and strong, Main: 100% Linen.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/36/3f/e67896c1b9380265335659f7fd42.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/16/94/5180ba5e67b72fd85c33a140dcef.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/15/db/c0b81c8877b5bd04892b9a578b26.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/fe/6e/e0d12cf0cd7766233da8bc70c0b8.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Tommy Hilfiger pigment dyed solid regular fit shirt",
                        Description = "A basic, but make it elevated, Button-down collar, Button placket, Logo embroidery to chest, Regular fit",
                        Price = 50,
                        Size = Size.M,
                        Color = "green",
                        Gender = Gender.Male,
                        Brand = nike,
                        Category = sportswear,
                        SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Linen: lightweight and strong, Main: 100% Linen.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/36/3f/e67896c1b9380265335659f7fd42.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/16/94/5180ba5e67b72fd85c33a140dcef.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/15/db/c0b81c8877b5bd04892b9a578b26.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/fe/6e/e0d12cf0cd7766233da8bc70c0b8.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Tommy Hilfiger pigment dyed solid regular fit shirt",
                        Description = "A basic, but make it elevated, Button-down collar, Button placket, Logo embroidery to chest, Regular fit",
                        Price = 50,
                        Size = Size.L,
                        Color = "green",
                        Gender = Gender.Male,
                        Brand = nike,
                        Category = sportswear,
                        SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Linen: lightweight and strong, Main: 100% Linen.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/36/3f/e67896c1b9380265335659f7fd42.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/16/94/5180ba5e67b72fd85c33a140dcef.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/15/db/c0b81c8877b5bd04892b9a578b26.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/fe/6e/e0d12cf0cd7766233da8bc70c0b8.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Tommy Hilfiger pigment dyed solid regular fit shirt",
                        Description = "A basic, but make it elevated, Button-down collar, Button placket, Logo embroidery to chest, Regular fit",
                        Price = 50,
                        Size = Size.XL,
                        Color = "green",
                        Gender = Gender.Male,
                        Brand = nike,
                        Category = sportswear,
                        SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Linen: lightweight and strong, Main: 100% Linen.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/36/3f/e67896c1b9380265335659f7fd42.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/16/94/5180ba5e67b72fd85c33a140dcef.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/15/db/c0b81c8877b5bd04892b9a578b26.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/fe/6e/e0d12cf0cd7766233da8bc70c0b8.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Tommy Hilfiger pigment dyed solid regular fit shirt",
                        Description = "A basic, but make it elevated, Button-down collar, Button placket, Logo embroidery to chest, Regular fit",
                        Price = 50,
                        Size = Size.XXL,
                        Color = "green",
                        Gender = Gender.Male,
                        Brand = nike,
                        Category = sportswear,
                        SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Linen: lightweight and strong, Main: 100% Linen.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/36/3f/e67896c1b9380265335659f7fd42.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/16/94/5180ba5e67b72fd85c33a140dcef.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/15/db/c0b81c8877b5bd04892b9a578b26.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/fe/6e/e0d12cf0cd7766233da8bc70c0b8.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Tommy Hilfiger pigment dyed solid regular fit shirt",
                        Description = "A basic, but make it elevated, Button-down collar, Button placket, Logo embroidery to chest, Regular fit",
                        Price = 50,
                        Size = Size.XXXL,
                        Color = "green",
                        Gender = Gender.Male,
                        Brand = nike,
                        Category = sportswear,
                        SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Linen: lightweight and strong, Main: 100% Linen.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/36/3f/e67896c1b9380265335659f7fd42.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/16/94/5180ba5e67b72fd85c33a140dcef.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/15/db/c0b81c8877b5bd04892b9a578b26.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://media.md-fashion.com.ua/images/fe/6e/e0d12cf0cd7766233da8bc70c0b8.jpg/cholovicha-blakytna-llyana-sorochka-pigment-dyed-li-solid-rf-tommy-hilfiger-mw0mw34602-blakytnyi.webp").Result
                            }
                        }
                    },




                  new ProductEntity
                  {

                        Name = "Adidas Football Entrada 22 joggers in black",
                        Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                        Price = 56,
                        Size = Size.XS,
                        Color = "black",
                        Gender = Gender.Male,
                        Brand = adidas,
                        Category = accessories,
                        SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester.",

                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(2/6/d/7/26d7fcff9df2486e2fdfcf34c43370d27849156e_02_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(6/a/7/d/6a7d682b61322760c367830e4660c40e07045a95_01_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/e/8/8/3e88e77254c5d4d528a2002a53185d0d9d047dc7_03_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/3/4/9/3349dd3ae249ff02217f4daea79e9dba5060f994_04_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            }
                        }
                  },

                  new ProductEntity
                  {

                      Name = "Adidas Football Entrada 22 joggers in black",
                      Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                      Price = 56,
                      Size = Size.S,
                      Color = "black",
                      Gender = Gender.Male,
                      Brand = adidas,
                      Category = accessories,
                      SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                      LookAfterMe = "Machine wash according to instructions on care label",
                      AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester.",

                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(2/6/d/7/26d7fcff9df2486e2fdfcf34c43370d27849156e_02_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(6/a/7/d/6a7d682b61322760c367830e4660c40e07045a95_01_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/e/8/8/3e88e77254c5d4d528a2002a53185d0d9d047dc7_03_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/3/4/9/3349dd3ae249ff02217f4daea79e9dba5060f994_04_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            }
                        }
                  },

                  new ProductEntity
                  {

                      Name = "Adidas Football Entrada 22 joggers in black",
                      Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                      Price = 56,
                      Size = Size.M,
                      Color = "black",
                      Gender = Gender.Male,
                      Brand = adidas,
                      Category = accessories,
                      SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                      LookAfterMe = "Machine wash according to instructions on care label",
                      AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester.",

                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(2/6/d/7/26d7fcff9df2486e2fdfcf34c43370d27849156e_02_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(6/a/7/d/6a7d682b61322760c367830e4660c40e07045a95_01_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/e/8/8/3e88e77254c5d4d528a2002a53185d0d9d047dc7_03_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/3/4/9/3349dd3ae249ff02217f4daea79e9dba5060f994_04_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            }
                        }
                  },

                  new ProductEntity
                  {

                      Name = "Adidas Football Entrada 22 joggers in black",
                      Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                      Price = 56,
                      Size = Size.L,
                      Color = "black",
                      Gender = Gender.Male,
                      Brand = adidas,
                      Category = accessories,
                      SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                      LookAfterMe = "Machine wash according to instructions on care label",
                      AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester.",

                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(2/6/d/7/26d7fcff9df2486e2fdfcf34c43370d27849156e_02_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(6/a/7/d/6a7d682b61322760c367830e4660c40e07045a95_01_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/e/8/8/3e88e77254c5d4d528a2002a53185d0d9d047dc7_03_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/3/4/9/3349dd3ae249ff02217f4daea79e9dba5060f994_04_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            }
                        }
                  },

                  new ProductEntity
                  {

                      Name = "Adidas Football Entrada 22 joggers in black",
                      Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                      Price = 56,
                      Size = Size.XL,
                      Color = "black",
                      Gender = Gender.Male,
                      Brand = adidas,
                      Category = accessories,
                      SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                      LookAfterMe = "Machine wash according to instructions on care label",
                      AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester.",

                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(2/6/d/7/26d7fcff9df2486e2fdfcf34c43370d27849156e_02_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(6/a/7/d/6a7d682b61322760c367830e4660c40e07045a95_01_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/e/8/8/3e88e77254c5d4d528a2002a53185d0d9d047dc7_03_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/3/4/9/3349dd3ae249ff02217f4daea79e9dba5060f994_04_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            }
                        }
                  },

                  new ProductEntity
                  {

                      Name = "Adidas Football Entrada 22 joggers in black",
                      Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                      Price = 56,
                      Size = Size.XXL,
                      Color = "black",
                      Gender = Gender.Male,
                      Brand = adidas,
                      Category = accessories,
                      SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                      LookAfterMe = "Machine wash according to instructions on care label",
                      AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester.",

                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(2/6/d/7/26d7fcff9df2486e2fdfcf34c43370d27849156e_02_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(6/a/7/d/6a7d682b61322760c367830e4660c40e07045a95_01_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/e/8/8/3e88e77254c5d4d528a2002a53185d0d9d047dc7_03_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/3/4/9/3349dd3ae249ff02217f4daea79e9dba5060f994_04_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            }
                        }
                  },

                  new ProductEntity
                  {

                      Name = "Adidas Football Entrada 22 joggers in black",
                      Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                      Price = 56,
                      Size = Size.XXXL,
                      Color = "black",
                      Gender = Gender.Male,
                      Brand = adidas,
                      Category = accessories,
                      SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                      LookAfterMe = "Machine wash according to instructions on care label",
                      AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester.",

                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(2/6/d/7/26d7fcff9df2486e2fdfcf34c43370d27849156e_02_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(6/a/7/d/6a7d682b61322760c367830e4660c40e07045a95_01_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/e/8/8/3e88e77254c5d4d528a2002a53185d0d9d047dc7_03_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://img.modivo.cloud/product(3/3/4/9/3349dd3ae249ff02217f4daea79e9dba5060f994_04_4066763500849.jpg,webp)/adidas-sportivni-shtani-in5102-chornii-regular-fit.webp").Result
                            }
                        }
                  },



                   new ProductEntity
                   {

                         Name = "DESIGN waterproof",
                         Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                         Price = 27,
                         Size = Size.XS,
                         Color = "black",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                         LookAfterMe = "Wipe clean with a soft dry cloth",
                         AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",


                       ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-4?$n_640w$&amp").Result
                            }
                        }
                   },

                    new ProductEntity
                    {

                        Name = "DESIGN waterproof",
                        Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                        Price = 27,
                        Size = Size.S,
                        Color = "black",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                        LookAfterMe = "Wipe clean with a soft dry cloth",
                        AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-4?$n_640w$&amp").Result
                            }
                        }
                    },

                     new ProductEntity
                     {

                         Name = "DESIGN waterproof",
                         Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                         Price = 27,
                         Size = Size.M,
                         Color = "black",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                         LookAfterMe = "Wipe clean with a soft dry cloth",
                         AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-4?$n_640w$&amp").Result
                            }
                        }
                     },

                      new ProductEntity
                      {

                          Name = "DESIGN waterproof",
                          Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                          Price = 27,
                          Size = Size.L,
                          Color = "black",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                          LookAfterMe = "Wipe clean with a soft dry cloth",
                          AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-4?$n_640w$&amp").Result
                            }
                        }
                      },

                       new ProductEntity
                       {

                           Name = "DESIGN waterproof",
                           Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                           Price = 27,
                           Size = Size.XL,
                           Color = "black",
                           Gender = Gender.Male,
                           Brand = asos,
                           Category = clothing,
                           SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                           LookAfterMe = "Wipe clean with a soft dry cloth",
                           AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",


                           ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-4?$n_640w$&amp").Result
                            }
                        }
                       },

                        new ProductEntity
                        {

                            Name = "DESIGN waterproof",
                            Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                            Price = 27,
                            Size = Size.XXL,
                            Color = "black",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                            LookAfterMe = "Wipe clean with a soft dry cloth",
                            AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",


                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-4?$n_640w$&amp").Result
                            }
                        }
                        },

                         new ProductEntity
                         {

                             Name = "DESIGN waterproof",
                             Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                             Price = 27,
                             Size = Size.XXXL,
                             Color = "black",
                             Gender = Gender.Male,
                             Brand = asos,
                             Category = clothing,
                             SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                             LookAfterMe = "Wipe clean with a soft dry cloth",
                             AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",


                             ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-shower-resistant-rubberised-rain-jacket-in-black/206229689-4?$n_640w$&amp").Result
                            }
                        }
                         },


                   new ProductEntity
                   {

                       Name = "Premium heavyweight tapered joggers in grey marl",
                       Description = "Exclusive to ASOS, our universal brand is here for you, and comes in Plus and Tall. Created by us, styled by you.",
                       Price = 30,
                       Size = Size.XS,
                       Color = "Grey Marl",
                       Gender = Gender.Male,
                       Brand = asos,
                       Category = clothing,
                       SizeAndFit = "Model's height: 185cm / 6' 1''\tModel is wearing: M - W34",
                       LookAfterMe = "Machine wash according to instructions on care label",
                       AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                       ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-1-greymarl?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-5?$n_640w$&amp").Result
                            }
                        }
                   },

                    new ProductEntity
                    {

                        Name = "Premium heavyweight tapered joggers in grey marl",
                        Description = "Exclusive to ASOS, our universal brand is here for you, and comes in Plus and Tall. Created by us, styled by you.",
                        Price = 30,
                        Size = Size.S,
                        Color = "Grey Marl",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "Model's height: 185cm / 6' 1''\tModel is wearing: M - W34",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-1-greymarl?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-5?$n_640w$&amp").Result
                            }
                        }
                    },

                     new ProductEntity
                     {

                         Name = "Premium heavyweight tapered joggers in grey marl",
                         Description = "Exclusive to ASOS, our universal brand is here for you, and comes in Plus and Tall. Created by us, styled by you.",
                         Price = 30,
                         Size = Size.M,
                         Color = "Grey Marl",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "Model's height: 185cm / 6' 1''\tModel is wearing: M - W34",
                         LookAfterMe = "Machine wash according to instructions on care label",
                         AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-1-greymarl?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-5?$n_640w$&amp").Result
                            }
                        }
                     },

                      new ProductEntity
                      {

                          Name = "Premium heavyweight tapered joggers in grey marl",
                          Description = "Exclusive to ASOS, our universal brand is here for you, and comes in Plus and Tall. Created by us, styled by you.",
                          Price = 30,
                          Size = Size.L,
                          Color = "Grey Marl",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 185cm / 6' 1''\tModel is wearing: M - W34",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-1-greymarl?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-5?$n_640w$&amp").Result
                            }
                        }
                      },

                       new ProductEntity
                       {

                           Name = "Premium heavyweight tapered joggers in grey marl",
                           Description = "Exclusive to ASOS, our universal brand is here for you, and comes in Plus and Tall. Created by us, styled by you.",
                           Price = 30,
                           Size = Size.XL,
                           Color = "Grey Marl",
                           Gender = Gender.Male,
                           Brand = asos,
                           Category = clothing,
                           SizeAndFit = "Model's height: 185cm / 6' 1''\tModel is wearing: M - W34",
                           LookAfterMe = "Machine wash according to instructions on care label",
                           AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                           ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-1-greymarl?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-5?$n_640w$&amp").Result
                            }
                        }
                       },

                        new ProductEntity
                        {

                            Name = "Premium heavyweight tapered joggers in grey marl",
                            Description = "Exclusive to ASOS, our universal brand is here for you, and comes in Plus and Tall. Created by us, styled by you.",
                            Price = 30,
                            Size = Size.XXL,
                            Color = "Grey Marl",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "Model's height: 185cm / 6' 1''\tModel is wearing: M - W34",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-1-greymarl?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-5?$n_640w$&amp").Result
                            }
                        }
                        },

                         new ProductEntity
                         {

                             Name = "Premium heavyweight tapered joggers in grey marl",
                             Description = "Exclusive to ASOS, our universal brand is here for you, and comes in Plus and Tall. Created by us, styled by you.",
                             Price = 30,
                             Size = Size.XXXL,
                             Color = "Grey Marl",
                             Gender = Gender.Male,
                             Brand = asos,
                             Category = clothing,
                             SizeAndFit = "Model's height: 185cm / 6' 1''\tModel is wearing: M - W34",
                             LookAfterMe = "Machine wash according to instructions on care label",
                             AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                             ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-1-greymarl?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-tapered-joggers-in-grey-marl/206586802-5?$n_640w$&amp").Result
                            }
                        }
                         },



                    new ProductEntity
                    {

                        Name = "Heavyweight oversized sweatshirt in washed black",
                        Description = "Hoodies & Sweatshirts by ASOS DESIGN\nFor 'no plans' plans\nCrew neck\nDrop shoulders\nRibbed trims\nOversized fit\nProduct Code: 131069247",
                        Price = 30,
                        Size = Size.XS,
                        Color = "Grey Marl",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "Model's height: 180cm/5'11\"\"\nModel is wearing: M - Chest 40",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm\nBody: 100% Cotton, Main: 100% Cotton, Trim: 97% Cotton, 3% Elastane.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-1-darkshadow?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Heavyweight oversized sweatshirt in washed black",
                        Description = "Hoodies & Sweatshirts by ASOS DESIGN\nFor 'no plans' plans\nCrew neck\nDrop shoulders\nRibbed trims\nOversized fit\nProduct Code: 131069247",
                        Price = 30,
                        Size = Size.S,
                        Color = "Grey Marl",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "Model's height: 180cm/5'11\"\"\nModel is wearing: M - Chest 40",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm\nBody: 100% Cotton, Main: 100% Cotton, Trim: 97% Cotton, 3% Elastane.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-1-darkshadow?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Heavyweight oversized sweatshirt in washed black",
                        Description = "Hoodies & Sweatshirts by ASOS DESIGN\nFor 'no plans' plans\nCrew neck\nDrop shoulders\nRibbed trims\nOversized fit\nProduct Code: 131069247",
                        Price = 30,
                        Size = Size.M,
                        Color = "Grey Marl",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "Model's height: 180cm/5'11\"\"\nModel is wearing: M - Chest 40",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm\nBody: 100% Cotton, Main: 100% Cotton, Trim: 97% Cotton, 3% Elastane.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-1-darkshadow?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Heavyweight oversized sweatshirt in washed black",
                        Description = "Hoodies & Sweatshirts by ASOS DESIGN\nFor 'no plans' plans\nCrew neck\nDrop shoulders\nRibbed trims\nOversized fit\nProduct Code: 131069247",
                        Price = 30,
                        Size = Size.L,
                        Color = "Grey Marl",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "Model's height: 180cm/5'11\"\"\nModel is wearing: M - Chest 40",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm\nBody: 100% Cotton, Main: 100% Cotton, Trim: 97% Cotton, 3% Elastane.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-1-darkshadow?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Heavyweight oversized sweatshirt in washed black",
                        Description = "Hoodies & Sweatshirts by ASOS DESIGN\nFor 'no plans' plans\nCrew neck\nDrop shoulders\nRibbed trims\nOversized fit\nProduct Code: 131069247",
                        Price = 30,
                        Size = Size.XL,
                        Color = "Grey Marl",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "Model's height: 180cm/5'11\"\"\nModel is wearing: M - Chest 40",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm\nBody: 100% Cotton, Main: 100% Cotton, Trim: 97% Cotton, 3% Elastane.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-1-darkshadow?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Heavyweight oversized sweatshirt in washed black",
                        Description = "Hoodies & Sweatshirts by ASOS DESIGN\nFor 'no plans' plans\nCrew neck\nDrop shoulders\nRibbed trims\nOversized fit\nProduct Code: 131069247",
                        Price = 30,
                        Size = Size.XXL,
                        Color = "Grey Marl",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "Model's height: 180cm/5'11\"\"\nModel is wearing: M - Chest 40",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm\nBody: 100% Cotton, Main: 100% Cotton, Trim: 97% Cotton, 3% Elastane.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-1-darkshadow?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Heavyweight oversized sweatshirt in washed black",
                        Description = "Hoodies & Sweatshirts by ASOS DESIGN\nFor 'no plans' plans\nCrew neck\nDrop shoulders\nRibbed trims\nOversized fit\nProduct Code: 131069247",
                        Price = 30,
                        Size = Size.XXXL,
                        Color = "Grey Marl",
                        Gender = Gender.Male,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "Model's height: 180cm/5'11\"\"\nModel is wearing: M - Chest 40",
                        LookAfterMe = "Machine wash according to instructions on care label",
                        AboutMe = "Sweatshirt fabric: soft and warm\nBody: 100% Cotton, Main: 100% Cotton, Trim: 97% Cotton, 3% Elastane.",


                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-1-darkshadow?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-sweatshirt-in-washed-black/204933493-4?$n_640w$&amp").Result
                            }
                        }
                    },



                     new ProductEntity
                     {

                         Name = "Heavyweight oversized hoodie",
                         Description = "Part of a co-ord set\r\nJoggers sold separately\r\nPlain design\r\nFixed hood\r\nLong sleeves\r\nPouch pocket\r\nRibbed trims\r\nOversized fit\r\nProduct Code: 135641579",
                         Price = 34,
                         Size = Size.XS,
                         Color = "Deep Cobalt",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "Model's height: 180cm/5'11\"\nModel is wearing: M - Chest 40",
                         LookAfterMe = "Machine wash according to instructions on care label",
                         AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-1-deepcobalt?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-4?$n_640w$&amp").Result
                            }
                        }
                     },

                     new ProductEntity
                     {

                         Name = "Heavyweight oversized hoodie",
                         Description = "Part of a co-ord set\r\nJoggers sold separately\r\nPlain design\r\nFixed hood\r\nLong sleeves\r\nPouch pocket\r\nRibbed trims\r\nOversized fit\r\nProduct Code: 135641579",
                         Price = 34,
                         Size = Size.S,
                         Color = "Deep Cobalt",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "Model's height: 180cm/5'11\"\nModel is wearing: M - Chest 40",
                         LookAfterMe = "Machine wash according to instructions on care label",
                         AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-1-deepcobalt?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-4?$n_640w$&amp").Result
                            }
                        }
                     },

                     new ProductEntity
                     {

                         Name = "Heavyweight oversized hoodie",
                         Description = "Part of a co-ord set\r\nJoggers sold separately\r\nPlain design\r\nFixed hood\r\nLong sleeves\r\nPouch pocket\r\nRibbed trims\r\nOversized fit\r\nProduct Code: 135641579",
                         Price = 34,
                         Size = Size.M,
                         Color = "Deep Cobalt",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "Model's height: 180cm/5'11\"\nModel is wearing: M - Chest 40",
                         LookAfterMe = "Machine wash according to instructions on care label",
                         AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-1-deepcobalt?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-4?$n_640w$&amp").Result
                            }
                        }
                     },

                     new ProductEntity
                     {

                         Name = "Heavyweight oversized hoodie",
                         Description = "Part of a co-ord set\r\nJoggers sold separately\r\nPlain design\r\nFixed hood\r\nLong sleeves\r\nPouch pocket\r\nRibbed trims\r\nOversized fit\r\nProduct Code: 135641579",
                         Price = 34,
                         Size = Size.L,
                         Color = "Deep Cobalt",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "Model's height: 180cm/5'11\"\nModel is wearing: M - Chest 40",
                         LookAfterMe = "Machine wash according to instructions on care label",
                         AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-1-deepcobalt?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-4?$n_640w$&amp").Result
                            }
                        }
                     },

                     new ProductEntity
                     {

                         Name = "Heavyweight oversized hoodie",
                         Description = "Part of a co-ord set\r\nJoggers sold separately\r\nPlain design\r\nFixed hood\r\nLong sleeves\r\nPouch pocket\r\nRibbed trims\r\nOversized fit\r\nProduct Code: 135641579",
                         Price = 34,
                         Size = Size.XL,
                         Color = "Deep Cobalt",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "Model's height: 180cm/5'11\"\nModel is wearing: M - Chest 40",
                         LookAfterMe = "Machine wash according to instructions on care label",
                         AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-1-deepcobalt?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-4?$n_640w$&amp").Result
                            }
                        }
                     },

                     new ProductEntity
                     {

                         Name = "Heavyweight oversized hoodie",
                         Description = "Part of a co-ord set\r\nJoggers sold separately\r\nPlain design\r\nFixed hood\r\nLong sleeves\r\nPouch pocket\r\nRibbed trims\r\nOversized fit\r\nProduct Code: 135641579",
                         Price = 34,
                         Size = Size.XXL,
                         Color = "Deep Cobalt",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "Model's height: 180cm/5'11\"\nModel is wearing: M - Chest 40",
                         LookAfterMe = "Machine wash according to instructions on care label",
                         AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-1-deepcobalt?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-4?$n_640w$&amp").Result
                            }
                        }
                     },

                     new ProductEntity
                     {

                         Name = "Heavyweight oversized hoodie",
                         Description = "Part of a co-ord set\r\nJoggers sold separately\r\nPlain design\r\nFixed hood\r\nLong sleeves\r\nPouch pocket\r\nRibbed trims\r\nOversized fit\r\nProduct Code: 135641579",
                         Price = 34,
                         Size = Size.XXXL,
                         Color = "Deep Cobalt",
                         Gender = Gender.Male,
                         Brand = asos,
                         Category = clothing,
                         SizeAndFit = "Model's height: 180cm/5'11\"\nModel is wearing: M - Chest 40",
                         LookAfterMe = "Machine wash according to instructions on care label",
                         AboutMe = "Sweatshirt fabric: soft and warm\nMain: 100% Cotton.",


                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-1-deepcobalt?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-heavyweight-oversized-hoodie-in-blue/206582853-4?$n_640w$&amp").Result
                            }
                        }
                     },



                      new ProductEntity
                      {

                          Name = "Essential oversized",
                          Description = "Adding to bag in 3, 2, 1…\nPlain design\nCrew neck\nDrop shoulders\nOversized fit\nProduct Code: 125769149",
                          Price = 10,
                          Size = Size.XS,
                          Color = "White",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 185cm / 6' 1''\nModel is wearing: M - Chest 40",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Jersey: soft and stretchy\nMain: 100% Cotton.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Essential oversized",
                          Description = "Adding to bag in 3, 2, 1…\nPlain design\nCrew neck\nDrop shoulders\nOversized fit\nProduct Code: 125769149",
                          Price = 10,
                          Size = Size.S,
                          Color = "White",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 185cm / 6' 1''\nModel is wearing: M - Chest 40",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Jersey: soft and stretchy\nMain: 100% Cotton.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Essential oversized",
                          Description = "Adding to bag in 3, 2, 1…\nPlain design\nCrew neck\nDrop shoulders\nOversized fit\nProduct Code: 125769149",
                          Price = 10,
                          Size = Size.M,
                          Color = "White",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 185cm / 6' 1''\nModel is wearing: M - Chest 40",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Jersey: soft and stretchy\nMain: 100% Cotton.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Essential oversized",
                          Description = "Adding to bag in 3, 2, 1…\nPlain design\nCrew neck\nDrop shoulders\nOversized fit\nProduct Code: 125769149",
                          Price = 10,
                          Size = Size.L,
                          Color = "White",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 185cm / 6' 1''\nModel is wearing: M - Chest 40",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Jersey: soft and stretchy\nMain: 100% Cotton.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Essential oversized",
                          Description = "Adding to bag in 3, 2, 1…\nPlain design\nCrew neck\nDrop shoulders\nOversized fit\nProduct Code: 125769149",
                          Price = 10,
                          Size = Size.XL,
                          Color = "White",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 185cm / 6' 1''\nModel is wearing: M - Chest 40",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Jersey: soft and stretchy\nMain: 100% Cotton.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Essential oversized",
                          Description = "Adding to bag in 3, 2, 1…\nPlain design\nCrew neck\nDrop shoulders\nOversized fit\nProduct Code: 125769149",
                          Price = 10,
                          Size = Size.XXL,
                          Color = "White",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 185cm / 6' 1''\nModel is wearing: M - Chest 40",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Jersey: soft and stretchy\nMain: 100% Cotton.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Essential oversized",
                          Description = "Adding to bag in 3, 2, 1…\nPlain design\nCrew neck\nDrop shoulders\nOversized fit\nProduct Code: 125769149",
                          Price = 10,
                          Size = Size.XXXL,
                          Color = "White",
                          Gender = Gender.Male,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 185cm / 6' 1''\nModel is wearing: M - Chest 40",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Jersey: soft and stretchy\nMain: 100% Cotton.",


                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-essential-oversized-t-shirt-in-white/204188293-4?$n_640w$&amp").Result
                            }
                        }
                      },



                    new ProductEntity
                    {

                        Name = "Premium waterproof cropped rain jacket in stone",
                        Description = "Your go-to for all the latest trends, no matter who you are, where you’re from and what you’re up to.",
                        Price = 105,
                        Size = Size.XS,
                        Color = "Charcoal",
                        Gender = Gender.Female,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                        LookAfterMe = "Wipe clean with a soft dry cloth",
                        AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",

                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-1-charcoal?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Premium waterproof cropped rain jacket in stone",
                        Description = "Your go-to for all the latest trends, no matter who you are, where you’re from and what you’re up to.",
                        Price = 105,
                        Size = Size.S,
                        Color = "Charcoal",
                        Gender = Gender.Female,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                        LookAfterMe = "Wipe clean with a soft dry cloth",
                        AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",

                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-1-charcoal?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Premium waterproof cropped rain jacket in stone",
                        Description = "Your go-to for all the latest trends, no matter who you are, where you’re from and what you’re up to.",
                        Price = 105,
                        Size = Size.M,
                        Color = "Charcoal",
                        Gender = Gender.Female,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                        LookAfterMe = "Wipe clean with a soft dry cloth",
                        AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",

                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-1-charcoal?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Premium waterproof cropped rain jacket in stone",
                        Description = "Your go-to for all the latest trends, no matter who you are, where you’re from and what you’re up to.",
                        Price = 105,
                        Size = Size.L,
                        Color = "Charcoal",
                        Gender = Gender.Female,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                        LookAfterMe = "Wipe clean with a soft dry cloth",
                        AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",

                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-1-charcoal?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Premium waterproof cropped rain jacket in stone",
                        Description = "Your go-to for all the latest trends, no matter who you are, where you’re from and what you’re up to.",
                        Price = 105,
                        Size = Size.XL,
                        Color = "Charcoal",
                        Gender = Gender.Female,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                        LookAfterMe = "Wipe clean with a soft dry cloth",
                        AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",

                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-1-charcoal?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Premium waterproof cropped rain jacket in stone",
                        Description = "Your go-to for all the latest trends, no matter who you are, where you’re from and what you’re up to.",
                        Price = 105,
                        Size = Size.XXL,
                        Color = "Charcoal",
                        Gender = Gender.Female,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                        LookAfterMe = "Wipe clean with a soft dry cloth",
                        AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",

                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-1-charcoal?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-4?$n_640w$&amp").Result
                            }
                        }
                    },

                    new ProductEntity
                    {

                        Name = "Premium waterproof cropped rain jacket in stone",
                        Description = "Your go-to for all the latest trends, no matter who you are, where you’re from and what you’re up to.",
                        Price = 105,
                        Size = Size.XXXL,
                        Color = "Charcoal",
                        Gender = Gender.Female,
                        Brand = asos,
                        Category = clothing,
                        SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                        LookAfterMe = "Wipe clean with a soft dry cloth",
                        AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel.",

                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-1-charcoal?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-premium-waterproof-cropped-rain-jacket-in-stone/205881652-4?$n_640w$&amp").Result
                            }
                        }
                    },


                      new ProductEntity
                      {

                          Name = "Linen mix mini dress in holiday print",
                          Description = "For brunch and beyond\nAll-over print\nHigh neck\nSleeveless style\nMini cut\nRegular fit\nProduct Code: 137320503",
                          Price = 30,
                          Size = Size.XS,
                          Color = "Multi",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: S - EU 36-38",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Plain-woven fabric\nMain: 81% Viscose, 19% Linen.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-1-multi?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Linen mix mini dress in holiday print",
                          Description = "For brunch and beyond\nAll-over print\nHigh neck\nSleeveless style\nMini cut\nRegular fit\nProduct Code: 137320503",
                          Price = 30,
                          Size = Size.S,
                          Color = "Multi",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: S - EU 36-38",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Plain-woven fabric\nMain: 81% Viscose, 19% Linen.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-1-multi?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Linen mix mini dress in holiday print",
                          Description = "For brunch and beyond\nAll-over print\nHigh neck\nSleeveless style\nMini cut\nRegular fit\nProduct Code: 137320503",
                          Price = 30,
                          Size = Size.M,
                          Color = "Multi",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: S - EU 36-38",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Plain-woven fabric\nMain: 81% Viscose, 19% Linen.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-1-multi?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Linen mix mini dress in holiday print",
                          Description = "For brunch and beyond\nAll-over print\nHigh neck\nSleeveless style\nMini cut\nRegular fit\nProduct Code: 137320503",
                          Price = 30,
                          Size = Size.L,
                          Color = "Multi",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: S - EU 36-38",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Plain-woven fabric\nMain: 81% Viscose, 19% Linen.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-1-multi?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Linen mix mini dress in holiday print",
                          Description = "For brunch and beyond\nAll-over print\nHigh neck\nSleeveless style\nMini cut\nRegular fit\nProduct Code: 137320503",
                          Price = 30,
                          Size = Size.XL,
                          Color = "Multi",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: S - EU 36-38",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Plain-woven fabric\nMain: 81% Viscose, 19% Linen.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-1-multi?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Linen mix mini dress in holiday print",
                          Description = "For brunch and beyond\nAll-over print\nHigh neck\nSleeveless style\nMini cut\nRegular fit\nProduct Code: 137320503",
                          Price = 30,
                          Size = Size.XXL,
                          Color = "Multi",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: S - EU 36-38",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Plain-woven fabric\nMain: 81% Viscose, 19% Linen.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-1-multi?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Linen mix mini dress in holiday print",
                          Description = "For brunch and beyond\nAll-over print\nHigh neck\nSleeveless style\nMini cut\nRegular fit\nProduct Code: 137320503",
                          Price = 30,
                          Size = Size.XXXL,
                          Color = "Multi",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: S - EU 36-38",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Plain-woven fabric\nMain: 81% Viscose, 19% Linen.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-1-multi?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-linen-mix-mini-dress-in-holiday-print/207059274-4?$n_640w$&amp").Result
                            }
                        }
                      },


                      new ProductEntity
                      {

                          Name = "Originals Samba OG trainers ",
                          Description = "Endless outfit possibilities\nLow-profile design\nLace-up fastening\nPadded tongue and cuff\nSignature adidas branding\nGum sole\nTextured grip tread\nProduct Code: 132176706",
                          Price = 105,
                          Size = Size.XS,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = adidas,
                          Category = sportswear,
                          SizeAndFit = "EU 35",
                          LookAfterMe = "The brand’s famous 3-Stripes can be seen on the track, field and in the latest streetwear trends",
                          AboutMe = "Leather and suede upper\nLining: 100% Textile, Sole: 100% Textile, Upper: 50% Leather, 50% Other materials.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-5?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Originals Samba OG trainers ",
                          Description = "Endless outfit possibilities\nLow-profile design\nLace-up fastening\nPadded tongue and cuff\nSignature adidas branding\nGum sole\nTextured grip tread\nProduct Code: 132176706",
                          Price = 105,
                          Size = Size.S,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = adidas,
                          Category = sportswear,
                          SizeAndFit = "EU 35",
                          LookAfterMe = "The brand’s famous 3-Stripes can be seen on the track, field and in the latest streetwear trends",
                          AboutMe = "Leather and suede upper\nLining: 100% Textile, Sole: 100% Textile, Upper: 50% Leather, 50% Other materials.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-5?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Originals Samba OG trainers ",
                          Description = "Endless outfit possibilities\nLow-profile design\nLace-up fastening\nPadded tongue and cuff\nSignature adidas branding\nGum sole\nTextured grip tread\nProduct Code: 132176706",
                          Price = 105,
                          Size = Size.M,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = adidas,
                          Category = sportswear,
                          SizeAndFit = "EU 35",
                          LookAfterMe = "The brand’s famous 3-Stripes can be seen on the track, field and in the latest streetwear trends",
                          AboutMe = "Leather and suede upper\nLining: 100% Textile, Sole: 100% Textile, Upper: 50% Leather, 50% Other materials.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-5?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Originals Samba OG trainers ",
                          Description = "Endless outfit possibilities\nLow-profile design\nLace-up fastening\nPadded tongue and cuff\nSignature adidas branding\nGum sole\nTextured grip tread\nProduct Code: 132176706",
                          Price = 105,
                          Size = Size.L,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = adidas,
                          Category = sportswear,
                          SizeAndFit = "EU 35",
                          LookAfterMe = "The brand’s famous 3-Stripes can be seen on the track, field and in the latest streetwear trends",
                          AboutMe = "Leather and suede upper\nLining: 100% Textile, Sole: 100% Textile, Upper: 50% Leather, 50% Other materials.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-5?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Originals Samba OG trainers ",
                          Description = "Endless outfit possibilities\nLow-profile design\nLace-up fastening\nPadded tongue and cuff\nSignature adidas branding\nGum sole\nTextured grip tread\nProduct Code: 132176706",
                          Price = 105,
                          Size = Size.XL,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = adidas,
                          Category = sportswear,
                          SizeAndFit = "EU 35",
                          LookAfterMe = "The brand’s famous 3-Stripes can be seen on the track, field and in the latest streetwear trends",
                          AboutMe = "Leather and suede upper\nLining: 100% Textile, Sole: 100% Textile, Upper: 50% Leather, 50% Other materials.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-5?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Originals Samba OG trainers ",
                          Description = "Endless outfit possibilities\nLow-profile design\nLace-up fastening\nPadded tongue and cuff\nSignature adidas branding\nGum sole\nTextured grip tread\nProduct Code: 132176706",
                          Price = 105,
                          Size = Size.XXL,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = adidas,
                          Category = sportswear,
                          SizeAndFit = "EU 35",
                          LookAfterMe = "The brand’s famous 3-Stripes can be seen on the track, field and in the latest streetwear trends",
                          AboutMe = "Leather and suede upper\nLining: 100% Textile, Sole: 100% Textile, Upper: 50% Leather, 50% Other materials.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-5?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Originals Samba OG trainers ",
                          Description = "Endless outfit possibilities\nLow-profile design\nLace-up fastening\nPadded tongue and cuff\nSignature adidas branding\nGum sole\nTextured grip tread\nProduct Code: 132176706",
                          Price = 105,
                          Size = Size.XXXL,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = adidas,
                          Category = sportswear,
                          SizeAndFit = "EU 35",
                          LookAfterMe = "The brand’s famous 3-Stripes can be seen on the track, field and in the latest streetwear trends",
                          AboutMe = "Leather and suede upper\nLining: 100% Textile, Sole: 100% Textile, Upper: 50% Leather, 50% Other materials.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-originals-samba-og-trainers-in-black/205091962-5?$n_640w$&amp").Result
                            }
                        }
                      },


                      new ProductEntity
                      {

                          Name = "Slim fit t-shirt in rib",
                          Description = "Your basket called, it wants this\nPlain design\nCrew neck\nShort sleeves\nSlim fit\nProduct Code: 1894532",
                          Price = 10,
                          Size = Size.XS,
                          Color = "green",
                          Gender = Gender.Female,
                          Brand = adidas,
                          Category = clothing,
                          SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: EU 36",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Ribbed jersey: soft and stretchy\nMain: 58% Cotton, 38% Polyester, 4% Elastane.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-4?$n_640w$&amp").Result
                            }
                        }
                      },

                       new ProductEntity
                       {

                           Name = "Slim fit t-shirt in rib",
                           Description = "Your basket called, it wants this\nPlain design\nCrew neck\nShort sleeves\nSlim fit\nProduct Code: 1894532",
                           Price = 10,
                           Size = Size.S,
                           Color = "dove",
                           Gender = Gender.Female,
                           Brand = adidas,
                           Category = clothing,
                           SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: EU 36",
                           LookAfterMe = "Machine wash according to instructions on care label",
                           AboutMe = "Ribbed jersey: soft and stretchy\nMain: 58% Cotton, 38% Polyester, 4% Elastane.",

                           ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-4?$n_640w$&amp").Result
                            }
                        }
                       },

                        new ProductEntity
                        {

                            Name = "Slim fit t-shirt in rib",
                            Description = "Your basket called, it wants this\nPlain design\nCrew neck\nShort sleeves\nSlim fit\nProduct Code: 1894532",
                            Price = 10,
                            Size = Size.M,
                            Color = "",
                            Gender = Gender.Female,
                            Brand = adidas,
                            Category = clothing,
                            SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: EU 36",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Ribbed jersey: soft and stretchy\nMain: 58% Cotton, 38% Polyester, 4% Elastane.",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-4?$n_640w$&amp").Result
                            }
                        }
                        },

                         new ProductEntity
                         {

                             Name = "Slim fit t-shirt in rib",
                             Description = "Your basket called, it wants this\nPlain design\nCrew neck\nShort sleeves\nSlim fit\nProduct Code: 1894532",
                             Price = 10,
                             Size = Size.L,
                             Color = "pink",
                             Gender = Gender.Female,
                             Brand = adidas,
                             Category = clothing,
                             SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: EU 36",
                             LookAfterMe = "Machine wash according to instructions on care label",
                             AboutMe = "Ribbed jersey: soft and stretchy\nMain: 58% Cotton, 38% Polyester, 4% Elastane.",

                             ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-4?$n_640w$&amp").Result
                            }
                        }
                         },

                          new ProductEntity
                          {

                              Name = "Slim fit t-shirt in rib",
                              Description = "Your basket called, it wants this\nPlain design\nCrew neck\nShort sleeves\nSlim fit\nProduct Code: 1894532",
                              Price = 10,
                              Size = Size.XL,
                              Color = "blue",
                              Gender = Gender.Female,
                              Brand = adidas,
                              Category = clothing,
                              SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: EU 36",
                              LookAfterMe = "Machine wash according to instructions on care label",
                              AboutMe = "Ribbed jersey: soft and stretchy\nMain: 58% Cotton, 38% Polyester, 4% Elastane.",

                              ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-4?$n_640w$&amp").Result
                            }
                        }
                          },

                           new ProductEntity
                           {

                               Name = "Slim fit t-shirt in rib",
                               Description = "Your basket called, it wants this\nPlain design\nCrew neck\nShort sleeves\nSlim fit\nProduct Code: 1894532",
                               Price = 10,
                               Size = Size.XXL,
                               Color = "yellow",
                               Gender = Gender.Female,
                               Brand = adidas,
                               Category = clothing,
                               SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: EU 36",
                               LookAfterMe = "Machine wash according to instructions on care label",
                               AboutMe = "Ribbed jersey: soft and stretchy\nMain: 58% Cotton, 38% Polyester, 4% Elastane.",

                               ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-4?$n_640w$&amp").Result
                            }
                        }
                           },

                            new ProductEntity
                            {

                                Name = "Slim fit t-shirt in rib",
                                Description = "Your basket called, it wants this\nPlain design\nCrew neck\nShort sleeves\nSlim fit\nProduct Code: 1894532",
                                Price = 10,
                                Size = Size.XXXL,
                                Color = "grey",
                                Gender = Gender.Female,
                                Brand = adidas,
                                Category = clothing,
                                SizeAndFit = "Model's height: 167.5cm / 5' 6''\nModel is wearing: EU 36",
                                LookAfterMe = "Machine wash according to instructions on care label",
                                AboutMe = "Ribbed jersey: soft and stretchy\nMain: 58% Cotton, 38% Polyester, 4% Elastane.",

                                ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-design-slim-fit-t-shirt-in-rib-in-black/22706463-4?$n_640w$&amp").Result
                            }
                        }
                            },


                      new ProductEntity
                      {

                          Name = "COLLUSION lettuce edge ribbed t-shirt",
                          Description = "Crew neck\nShort sleeves\nLettuce edge trims\nRegular fit\nProduct Code: 133663212",
                          Price = 7,
                          Size = Size.XS,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 173.5cm / 5' 8½''\nModel is wearing: UK 8/ EU 36/ US 4",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Ribbed jersey: soft and stretchy\nMain: 96% Cotton, 4% Elastane.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "COLLUSION lettuce edge ribbed t-shirt",
                          Description = "Crew neck\nShort sleeves\nLettuce edge trims\nRegular fit\nProduct Code: 133663212",
                          Price = 7,
                          Size = Size.S,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 173.5cm / 5' 8½''\nModel is wearing: UK 8/ EU 36/ US 4",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Ribbed jersey: soft and stretchy\nMain: 96% Cotton, 4% Elastane.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "COLLUSION lettuce edge ribbed t-shirt",
                          Description = "Crew neck\nShort sleeves\nLettuce edge trims\nRegular fit\nProduct Code: 133663212",
                          Price = 7,
                          Size = Size.M,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 173.5cm / 5' 8½''\nModel is wearing: UK 8/ EU 36/ US 4",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Ribbed jersey: soft and stretchy\nMain: 96% Cotton, 4% Elastane.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "COLLUSION lettuce edge ribbed t-shirt",
                          Description = "Crew neck\nShort sleeves\nLettuce edge trims\nRegular fit\nProduct Code: 133663212",
                          Price = 7,
                          Size = Size.L,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 173.5cm / 5' 8½''\nModel is wearing: UK 8/ EU 36/ US 4",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Ribbed jersey: soft and stretchy\nMain: 96% Cotton, 4% Elastane.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "COLLUSION lettuce edge ribbed t-shirt",
                          Description = "Crew neck\nShort sleeves\nLettuce edge trims\nRegular fit\nProduct Code: 133663212",
                          Price = 7,
                          Size = Size.XL,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 173.5cm / 5' 8½''\nModel is wearing: UK 8/ EU 36/ US 4",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Ribbed jersey: soft and stretchy\nMain: 96% Cotton, 4% Elastane.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "COLLUSION lettuce edge ribbed t-shirt",
                          Description = "Crew neck\nShort sleeves\nLettuce edge trims\nRegular fit\nProduct Code: 133663212",
                          Price = 7,
                          Size = Size.XXL,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 173.5cm / 5' 8½''\nModel is wearing: UK 8/ EU 36/ US 4",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Ribbed jersey: soft and stretchy\nMain: 96% Cotton, 4% Elastane.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "COLLUSION lettuce edge ribbed t-shirt",
                          Description = "Crew neck\nShort sleeves\nLettuce edge trims\nRegular fit\nProduct Code: 133663212",
                          Price = 7,
                          Size = Size.XXXL,
                          Color = "Black",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 173.5cm / 5' 8½''\nModel is wearing: UK 8/ EU 36/ US 4",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Ribbed jersey: soft and stretchy\nMain: 96% Cotton, 4% Elastane.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-1-black?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/collusion-lettuce-edge-ribbed-t-shirt-in-black/205751571-4?$n_640w$&amp").Result
                            }
                        }
                      },


                      new ProductEntity
                      {

                          Name = "Panel maxi dress with open back detail and asymmetric hem in white",
                          Description = "Too good to only wear once\nOne-shoulder style\nFixed straps\nLace panels\nTie-back fastening\nRegular fit\nProduct Code: 134743612",
                          Price = 205,
                          Size = Size.XS,
                          Color = "White",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 177.5cm / 5' 10''\nModel is wearing: EU 36",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Broderie anglaise: lightweight fabric with an embroidered, cut-out pattern\nMain: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Panel maxi dress with open back detail and asymmetric hem in white",
                          Description = "Too good to only wear once\nOne-shoulder style\nFixed straps\nLace panels\nTie-back fastening\nRegular fit\nProduct Code: 134743612",
                          Price = 205,
                          Size = Size.S,
                          Color = "White",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 177.5cm / 5' 10''\nModel is wearing: EU 36",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Broderie anglaise: lightweight fabric with an embroidered, cut-out pattern\nMain: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Panel maxi dress with open back detail and asymmetric hem in white",
                          Description = "Too good to only wear once\nOne-shoulder style\nFixed straps\nLace panels\nTie-back fastening\nRegular fit\nProduct Code: 134743612",
                          Price = 205,
                          Size = Size.M,
                          Color = "White",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 177.5cm / 5' 10''\nModel is wearing: EU 36",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Broderie anglaise: lightweight fabric with an embroidered, cut-out pattern\nMain: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Panel maxi dress with open back detail and asymmetric hem in white",
                          Description = "Too good to only wear once\nOne-shoulder style\nFixed straps\nLace panels\nTie-back fastening\nRegular fit\nProduct Code: 134743612",
                          Price = 205,
                          Size = Size.L,
                          Color = "White",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 177.5cm / 5' 10''\nModel is wearing: EU 36",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Broderie anglaise: lightweight fabric with an embroidered, cut-out pattern\nMain: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Panel maxi dress with open back detail and asymmetric hem in white",
                          Description = "Too good to only wear once\nOne-shoulder style\nFixed straps\nLace panels\nTie-back fastening\nRegular fit\nProduct Code: 134743612",
                          Price = 205,
                          Size = Size.XL,
                          Color = "White",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 177.5cm / 5' 10''\nModel is wearing: EU 36",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Broderie anglaise: lightweight fabric with an embroidered, cut-out pattern\nMain: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Panel maxi dress with open back detail and asymmetric hem in white",
                          Description = "Too good to only wear once\nOne-shoulder style\nFixed straps\nLace panels\nTie-back fastening\nRegular fit\nProduct Code: 134743612",
                          Price = 205,
                          Size = Size.XXL,
                          Color = "White",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 177.5cm / 5' 10''\nModel is wearing: EU 36",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Broderie anglaise: lightweight fabric with an embroidered, cut-out pattern\nMain: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Panel maxi dress with open back detail and asymmetric hem in white",
                          Description = "Too good to only wear once\nOne-shoulder style\nFixed straps\nLace panels\nTie-back fastening\nRegular fit\nProduct Code: 134743612",
                          Price = 205,
                          Size = Size.XXXL,
                          Color = "White",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 177.5cm / 5' 10''\nModel is wearing: EU 36",
                          LookAfterMe = "Machine wash according to instructions on care label",
                          AboutMe = "Broderie anglaise: lightweight fabric with an embroidered, cut-out pattern\nMain: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-1-white?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-edition-embroidered-lace-panel-maxi-dress-with-open-back-detail-and-asymmetric-hem-in-white/206257813-4?$n_640w$&amp").Result
                            }
                        }
                      },



                      new ProductEntity
                      {

                          Name = "Pearl embellished starfish crochet beach maxi dress in cream",
                          Description = "Spotlight-stealing style\nHalterneck style\nCup details\nFaux-pearl embellishments\nTie-back fastening\nSlim fit\nProduct Code: 134860280",
                          Price = 205,
                          Size = Size.XS,
                          Color = "Cream",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 175.5cm / 5' 9''\nModel is wearing: EU 36",
                          LookAfterMe = "Hand wash only",
                          AboutMe = "Crochet: patterned with a handmade look\nLining: 100% Polyester, Shell: 100% Polyester, Trim: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-1-cream?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Pearl embellished starfish crochet beach maxi dress in cream",
                          Description = "Spotlight-stealing style\nHalterneck style\nCup details\nFaux-pearl embellishments\nTie-back fastening\nSlim fit\nProduct Code: 134860280",
                          Price = 205,
                          Size = Size.S,
                          Color = "Cream",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 175.5cm / 5' 9''\nModel is wearing: EU 36",
                          LookAfterMe = "Hand wash only",
                          AboutMe = "Crochet: patterned with a handmade look\nLining: 100% Polyester, Shell: 100% Polyester, Trim: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-1-cream?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Pearl embellished starfish crochet beach maxi dress in cream",
                          Description = "Spotlight-stealing style\nHalterneck style\nCup details\nFaux-pearl embellishments\nTie-back fastening\nSlim fit\nProduct Code: 134860280",
                          Price = 205,
                          Size = Size.M,
                          Color = "Cream",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 175.5cm / 5' 9''\nModel is wearing: EU 36",
                          LookAfterMe = "Hand wash only",
                          AboutMe = "Crochet: patterned with a handmade look\nLining: 100% Polyester, Shell: 100% Polyester, Trim: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-1-cream?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Pearl embellished starfish crochet beach maxi dress in cream",
                          Description = "Spotlight-stealing style\nHalterneck style\nCup details\nFaux-pearl embellishments\nTie-back fastening\nSlim fit\nProduct Code: 134860280",
                          Price = 205,
                          Size = Size.L,
                          Color = "Cream",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 175.5cm / 5' 9''\nModel is wearing: EU 36",
                          LookAfterMe = "Hand wash only",
                          AboutMe = "Crochet: patterned with a handmade look\nLining: 100% Polyester, Shell: 100% Polyester, Trim: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-1-cream?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Pearl embellished starfish crochet beach maxi dress in cream",
                          Description = "Spotlight-stealing style\nHalterneck style\nCup details\nFaux-pearl embellishments\nTie-back fastening\nSlim fit\nProduct Code: 134860280",
                          Price = 205,
                          Size = Size.XL,
                          Color = "Cream",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 175.5cm / 5' 9''\nModel is wearing: EU 36",
                          LookAfterMe = "Hand wash only",
                          AboutMe = "Crochet: patterned with a handmade look\nLining: 100% Polyester, Shell: 100% Polyester, Trim: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-1-cream?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Pearl embellished starfish crochet beach maxi dress in cream",
                          Description = "Spotlight-stealing style\nHalterneck style\nCup details\nFaux-pearl embellishments\nTie-back fastening\nSlim fit\nProduct Code: 134860280",
                          Price = 205,
                          Size = Size.XXL,
                          Color = "Cream",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 175.5cm / 5' 9''\nModel is wearing: EU 36",
                          LookAfterMe = "Hand wash only",
                          AboutMe = "Crochet: patterned with a handmade look\nLining: 100% Polyester, Shell: 100% Polyester, Trim: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-1-cream?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-4?$n_640w$&amp").Result
                            }
                        }
                      },

                      new ProductEntity
                      {

                          Name = "Pearl embellished starfish crochet beach maxi dress in cream",
                          Description = "Spotlight-stealing style\nHalterneck style\nCup details\nFaux-pearl embellishments\nTie-back fastening\nSlim fit\nProduct Code: 134860280",
                          Price = 205,
                          Size = Size.XXXL,
                          Color = "Cream",
                          Gender = Gender.Female,
                          Brand = asos,
                          Category = clothing,
                          SizeAndFit = "Model's height: 175.5cm / 5' 9''\nModel is wearing: EU 36",
                          LookAfterMe = "Hand wash only",
                          AboutMe = "Crochet: patterned with a handmade look\nLining: 100% Polyester, Shell: 100% Polyester, Trim: 100% Cotton.",

                          ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-1-cream?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-3?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/asos-luxe-pearl-embellished-starfish-crochet-beach-maxi-dress-in-cream/206310380-4?$n_640w$&amp").Result
                            }
                        }
                      },


                        new ProductEntity
                        {

                            Name = "adidas Training Essentials 1/4 zip top in grey",
                            Description = "Jackets & Coats by adidas performance",
                            Price = 38,
                            Size = Size.XS,
                            Color = "Grey",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "Model's height: 188cm / 6' 2''\nModel is wearing: M",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Sportswear: smooth and stretchy fabric \nUses adidas AEROREADY technology\nMoisture-absorbing and quick-drying",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-1-grey?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-3?$n_640w$&amp").Result
                            }
                        }
                        },

                        new ProductEntity
                        {

                            Name = "adidas Training Essentials 1/4 zip top in grey",
                            Description = "Jackets & Coats by adidas performance",
                            Price = 38,
                            Size = Size.S,
                            Color = "Grey",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "Model's height: 188cm / 6' 2''\nModel is wearing: M",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Sportswear: smooth and stretchy fabric \nUses adidas AEROREADY technology\nMoisture-absorbing and quick-drying",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-1-grey?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-3?$n_640w$&amp").Result
                            }
                        }
                        },

                        new ProductEntity
                        {

                            Name = "adidas Training Essentials 1/4 zip top in grey",
                            Description = "Jackets & Coats by adidas performance",
                            Price = 38,
                            Size = Size.M,
                            Color = "Grey",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "Model's height: 188cm / 6' 2''\nModel is wearing: M",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Sportswear: smooth and stretchy fabric \nUses adidas AEROREADY technology\nMoisture-absorbing and quick-drying",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-1-grey?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-3?$n_640w$&amp").Result
                            }
                        }
                        },

                        new ProductEntity
                        {

                            Name = "adidas Training Essentials 1/4 zip top in grey",
                            Description = "Jackets & Coats by adidas performance",
                            Price = 38,
                            Size = Size.L,
                            Color = "Grey",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "Model's height: 188cm / 6' 2''\nModel is wearing: M",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Sportswear: smooth and stretchy fabric \nUses adidas AEROREADY technology\nMoisture-absorbing and quick-drying",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-1-grey?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-3?$n_640w$&amp").Result
                            }
                        }
                        },

                        new ProductEntity
                        {

                            Name = "adidas Training Essentials 1/4 zip top in grey",
                            Description = "Jackets & Coats by adidas performance",
                            Price = 38,
                            Size = Size.XL,
                            Color = "Grey",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "Model's height: 188cm / 6' 2''\nModel is wearing: M",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Sportswear: smooth and stretchy fabric \nUses adidas AEROREADY technology\nMoisture-absorbing and quick-drying",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-1-grey?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-3?$n_640w$&amp").Result
                            }
                        }
                        },

                        new ProductEntity
                        {

                            Name = "adidas Training Essentials 1/4 zip top in grey",
                            Description = "Jackets & Coats by adidas performance",
                            Price = 38,
                            Size = Size.XXL,
                            Color = "Grey",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "Model's height: 188cm / 6' 2''\nModel is wearing: M",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Sportswear: smooth and stretchy fabric \nUses adidas AEROREADY technology\nMoisture-absorbing and quick-drying",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-1-grey?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-3?$n_640w$&amp").Result
                            }
                        }
                        },

                        new ProductEntity
                        {

                            Name = "adidas Training Essentials 1/4 zip top in grey",
                            Description = "Jackets & Coats by adidas performance",
                            Price = 38,
                            Size = Size.XXXL,
                            Color = "Grey",
                            Gender = Gender.Male,
                            Brand = asos,
                            Category = clothing,
                            SizeAndFit = "Model's height: 188cm / 6' 2''\nModel is wearing: M",
                            LookAfterMe = "Machine wash according to instructions on care label",
                            AboutMe = "Sportswear: smooth and stretchy fabric \nUses adidas AEROREADY technology\nMoisture-absorbing and quick-drying",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-4?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-1-grey?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-2?$n_640w$&amp").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/adidas-training-essentials-1-4-zip-top-in-grey/206083186-3?$n_640w$&amp").Result
                            }
                        }
                        }


                 );
                    context.SaveChanges();
                }
                #endregion

                #region Country

                if (!context.Country.Any())
                {
                    CountryEntity[] countries = new CountryEntity[]
                {
                                    new CountryEntity{NameCountry="Україна"},
                                    new CountryEntity{NameCountry="Австралія"},
                                    new CountryEntity{NameCountry="Австрія"},
                                    new CountryEntity{NameCountry="Азербайджан"},
                                    new CountryEntity{NameCountry="Албанія"},
                                    new CountryEntity{NameCountry="Алжир"},
                                    new CountryEntity{NameCountry="Ангола"},
                                    new CountryEntity{NameCountry="Андорра"},
                                    new CountryEntity{NameCountry="Антигуа та Барбуда"},
                                    new CountryEntity{NameCountry="Аргентина"},
                                    new CountryEntity{NameCountry="Афганістан"},
                                    new CountryEntity{NameCountry="Багамські Острови"},
                                    new CountryEntity{NameCountry="Бангладеш"},
                                    new CountryEntity{NameCountry="Барбадос"},
                                    new CountryEntity{NameCountry="Бахрейн"},
                                    new CountryEntity{NameCountry="Беліз"},
                                    new CountryEntity{NameCountry="Бельгія"},
                                    new CountryEntity{NameCountry="Бенін"},
                                    new CountryEntity{NameCountry="Білорусь"},
                                    new CountryEntity{NameCountry="Болгарія"},
                                    new CountryEntity{NameCountry="Болівія"},
                                    new CountryEntity{NameCountry="Боснія та Герцеговина"},
                                    new CountryEntity{NameCountry="Ботсвана"},
                                    new CountryEntity{NameCountry="Бразилія"},
                                    new CountryEntity{NameCountry="Бруней"},
                                    new CountryEntity{NameCountry="Буркіна-Фасо"},
                                    new CountryEntity{NameCountry="Бурунді"},
                                    new CountryEntity{NameCountry="Бутан"},
                                    new CountryEntity{NameCountry="Вануату"},
                                    new CountryEntity{NameCountry="Ватикан"},
                                    new CountryEntity{NameCountry="В’єтнам"},
                                    new CountryEntity{NameCountry="Велика Британія"},
                                    new CountryEntity{NameCountry="Венесуела"},
                                    new CountryEntity{NameCountry="Вірменія"},
                                    new CountryEntity{NameCountry="Габон"},
                                    new CountryEntity{NameCountry="Гаїті"},
                                    new CountryEntity{NameCountry="Гайяна"},
                                    new CountryEntity{NameCountry="Гамбія"},
                                    new CountryEntity{NameCountry="Гана"},
                                    new CountryEntity{NameCountry="Гватемала"},
                                    new CountryEntity{NameCountry="Гвінея"},
                                    new CountryEntity{NameCountry="Гвінея-Бісау"},
                                    new CountryEntity{NameCountry="Гондурас"},
                                    new CountryEntity{NameCountry="Гренада"},
                                    new CountryEntity{NameCountry="Греція"},
                                    new CountryEntity{NameCountry="Грузія"},
                                    new CountryEntity{NameCountry="Данія"},
                                    new CountryEntity{NameCountry="Демократична Республіка Конго"},
                                    new CountryEntity{NameCountry="Джибуті"},
                                    new CountryEntity{NameCountry="Домініка"},
                                    new CountryEntity{NameCountry="Домініканська Республіка"},
                                    new CountryEntity{NameCountry="Еквадор"},
                                    new CountryEntity{NameCountry="Екваторіальна Гвінея"},
                                    new CountryEntity{NameCountry="Еритрея"},
                                    new CountryEntity{NameCountry="Естонія"},
                                    new CountryEntity{NameCountry="Ефіопія"},
                                    new CountryEntity{NameCountry="Єгипет"},
                                    new CountryEntity{NameCountry="Ємен"},
                                    new CountryEntity{NameCountry="Замбія"},
                                    new CountryEntity{NameCountry="Зімбабве"},
                                    new CountryEntity{NameCountry="Ізраїль"},
                                    new CountryEntity{NameCountry="Індія"},
                                    new CountryEntity{NameCountry="Індонезія"},
                                    new CountryEntity{NameCountry="Ірак"},
                                    new CountryEntity{NameCountry="Іран"},
                                    new CountryEntity{NameCountry="Ірландія"},
                                    new CountryEntity{NameCountry="Ісландія"},
                                    new CountryEntity{NameCountry="Іспанія"},
                                    new CountryEntity{NameCountry="Італія"},
                                    new CountryEntity{NameCountry="Йорданія"},
                                    new CountryEntity{NameCountry="Кабо-Верде"},
                                    new CountryEntity{NameCountry="Казахстан"},
                                    new CountryEntity{NameCountry="Камбоджа"},
                                    new CountryEntity{NameCountry="Камерун"},
                                    new CountryEntity{NameCountry="Канада"},
                                    new CountryEntity{NameCountry="Катар"},
                                    new CountryEntity{NameCountry="Кенія"},
                                    new CountryEntity{NameCountry="Киргизстан"},
                                    new CountryEntity{NameCountry="Китай"},
                                    new CountryEntity{NameCountry="Кірибаті"},
                                    new CountryEntity{NameCountry="Колумбія"},
                                    new CountryEntity{NameCountry="Коморські Острови"},
                                    new CountryEntity{NameCountry="Конго"},
                                    new CountryEntity{NameCountry="Корея Південна (Республіка Корея)"},
                                    new CountryEntity{NameCountry="Корея Північна (КНДР)"},
                                    new CountryEntity{NameCountry="Косово"},
                                    new CountryEntity{NameCountry="Коста-Ріка"},
                                    new CountryEntity{NameCountry="Кот-д’Івуар"},
                                    new CountryEntity{NameCountry="Куба"},
                                    new CountryEntity{NameCountry="Кувейт"},
                                    new CountryEntity{NameCountry="Лаос"},
                                    new CountryEntity{NameCountry="Латвія"},
                                    new CountryEntity{NameCountry="Лесото"},
                                    new CountryEntity{NameCountry="Литва"},
                                    new CountryEntity{NameCountry="Ліберія"},
                                    new CountryEntity{NameCountry="Ліван"},
                                    new CountryEntity{NameCountry="Лівія"},
                                    new CountryEntity{NameCountry="Ліхтенштейн"},
                                    new CountryEntity{NameCountry="Люксембург"},
                                    new CountryEntity{NameCountry="Маврикій"},
                                    new CountryEntity{NameCountry="Мавританія"},
                                    new CountryEntity{NameCountry="Мадагаскар"},
                                    new CountryEntity{NameCountry="Македонія Північна"},
                                    new CountryEntity{NameCountry="Малаві"},
                                    new CountryEntity{NameCountry="Малайзія"},
                                    new CountryEntity{NameCountry="Малі"},
                                    new CountryEntity{NameCountry="Мальдіви"},
                                    new CountryEntity{NameCountry="Мальта"},
                                    new CountryEntity{NameCountry="Марокко"},
                                    new CountryEntity{NameCountry="Маршаллові Острови"},
                                    new CountryEntity{NameCountry="Мексика"},
                                    new CountryEntity{NameCountry="Мозамбік"},
                                    new CountryEntity{NameCountry="Молдова"},
                                    new CountryEntity{NameCountry="Монако"},
                                    new CountryEntity{NameCountry="Монголія"},
                                    new CountryEntity{NameCountry="М’янма"},
                                    new CountryEntity{NameCountry="Намібія"},
                                    new CountryEntity{NameCountry="Науру"},
                                    new CountryEntity{NameCountry="Непал"},
                                    new CountryEntity{NameCountry="Нігер"},
                                    new CountryEntity{NameCountry="Нігерія"},
                                    new CountryEntity{NameCountry="Нідерланди"},
                                    new CountryEntity{NameCountry="Нікарагуа"},
                                    new CountryEntity{NameCountry="Німеччина"},
                                    new CountryEntity{NameCountry="Нова Зеландія"},
                                    new CountryEntity{NameCountry="Норвегія"},
                                    new CountryEntity{NameCountry="Об’єднані Арабські Емірати (ОАЕ)"},
                                    new CountryEntity{NameCountry="Оман"},
                                    new CountryEntity{NameCountry="Пакистан"},
                                    new CountryEntity{NameCountry="Палау"},
                                    new CountryEntity{NameCountry="Панама"},
                                    new CountryEntity{NameCountry="Папуа-Нова Гвінея"},
                                    new CountryEntity{NameCountry="Парагвай"},
                                    new CountryEntity{NameCountry="Перу"},
                                    new CountryEntity{NameCountry="Південна Африка"},
                                    new CountryEntity{NameCountry="Південний Судан"},
                                    new CountryEntity{NameCountry="Польща"},
                                    new CountryEntity{NameCountry="Португалія"},
                                    new CountryEntity{NameCountry="Росія"},
                                    new CountryEntity{NameCountry="Руанда"},
                                    new CountryEntity{NameCountry="Румунія"},
                                    new CountryEntity{NameCountry="Сальвадор"},
                                    new CountryEntity{NameCountry="Самоа"},
                                    new CountryEntity{NameCountry="Сан-Марино"},
                                    new CountryEntity{NameCountry="Сан-Томе і Прінсіпі"},
                                    new CountryEntity{NameCountry="Саудівська Аравія"},
                                    new CountryEntity{NameCountry="Свазіленд"},
                                    new CountryEntity{NameCountry="Сейшельські Острови"},
                                    new CountryEntity{NameCountry="Сенегал"},
                                    new CountryEntity{NameCountry="Сент-Вінсент і Гренадини"},
                                    new CountryEntity{NameCountry="Сент-Кіттс і Невіс"},
                                    new CountryEntity{NameCountry="Сент-Люсія"},
                                    new CountryEntity{NameCountry="Сербія"},
                                    new CountryEntity{NameCountry="Сирія"},
                                    new CountryEntity{NameCountry="Сінгапур"},
                                    new CountryEntity{NameCountry="Словаччина"},
                                    new CountryEntity{NameCountry="Словенія"},
                                    new CountryEntity{NameCountry="Соломонові Острови"},
                                    new CountryEntity{NameCountry="Сомалі"},
                                    new CountryEntity{NameCountry="Сполучені Штати Америки"},
                                    new CountryEntity{NameCountry="Судан"},
                                    new CountryEntity{NameCountry="Сурінам"},
                                    new CountryEntity{NameCountry="Східний Тімор"},
                                    new CountryEntity{NameCountry="Сьєрра-Леоне"},
                                    new CountryEntity{NameCountry="Таджикістан"},
                                    new CountryEntity{NameCountry="Таїланд"},
                                    new CountryEntity{NameCountry="Танзанія"},
                                    new CountryEntity{NameCountry="Того"},
                                    new CountryEntity{NameCountry="Тонга"},
                                    new CountryEntity{NameCountry="Тринідад і Тобаго"},
                                    new CountryEntity{NameCountry="Тувалу"},
                                    new CountryEntity{NameCountry="Туніс"},
                                    new CountryEntity{NameCountry="Туреччина"},
                                    new CountryEntity{NameCountry="Туркменістан"},
                                    new CountryEntity{NameCountry="Уганда"},
                                    new CountryEntity{NameCountry="Угорщина"},
                                    new CountryEntity{NameCountry="Узбекистан"},
                                    new CountryEntity{NameCountry="Уругвай"},
                                    new CountryEntity{NameCountry="Федеративні Штати Мікронезії"},
                                    new CountryEntity{NameCountry="Фіджі"},
                                    new CountryEntity{NameCountry="Філіппіни"},
                                    new CountryEntity{NameCountry="Фінляндія"},
                                    new CountryEntity{NameCountry="Франція"},
                                    new CountryEntity{NameCountry="Хорватія"},
                                    new CountryEntity{NameCountry="Центральноафриканська Республіка"},
                                    new CountryEntity{NameCountry="Чад"},
                                    new CountryEntity{NameCountry="Чехія"},
                                    new CountryEntity{NameCountry="Чилі"},
                                    new CountryEntity{NameCountry="Чорногорія"},
                                    new CountryEntity{NameCountry="Швейцарія"},
                                    new CountryEntity{NameCountry="Швеція"},
                                    new CountryEntity{NameCountry="Шрі-Ланка"},
                                    new CountryEntity{NameCountry="Ямайка"},
                                    new CountryEntity{NameCountry="Японія"}
             };

                    context.Country.AddRange(countries);
                    context.SaveChanges();
                }

                #endregion

                #region OrderStatus

                if(!context.OrderStatus.Any())
                {
                    var booked = new OrderStatusEntity { Name = "Booked" };
                    var delivery = new OrderStatusEntity { Name = "Delivery" };
                    var bought = new OrderStatusEntity { Name = "Bought" };

                    context.OrderStatus.AddRange([booked, delivery, bought]);

                    context.SaveChanges();

                }

                #endregion
            }
        }
    }


}


