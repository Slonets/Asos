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
                        },




                        new ProductEntity
                        {

                            Name = "The INKEY List Hyaluronic Acid Serum 30ml",
                            Description = "Skincare can be confusing with ingredients that sound more sci-fi than soothing",
                            Price = 8,
                            Size = Size.XXXL,
                            Color = "Grey",
                            Gender = Gender.Female,
                            Brand = asos,
                            Category = makeup,
                            SizeAndFit = "Product size: 30ml\r\nSizing Help\r\nStill unsure what size to get? Check out our size guide.",
                            LookAfterMe = "Massage into face and neck each morning\r\n\r\nNot required: 100% Not required.",
                            AboutMe = "Face + Body by THE INKEY LIST\r\nFor your self-care shelf\r\nHydrating serum\r\nDesigned to smooth and hydrate skin\r\nSuitable for all skin types",

                            ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/the-inkey-list-hyaluronic-acid-serum-30ml/203092184-1-30ml?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/the-inkey-list-hyaluronic-acid-serum-30ml/203092184-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/the-inkey-list-hyaluronic-acid-serum-30ml/203092184-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/the-inkey-list-hyaluronic-acid-serum-30ml/203092184-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                        },
                         new ProductEntity
                         {

                             Name = "Pixi BeautifEYE Brightening Hydrogel Eye Mask Patches 30 Pairs",
                             Description = "Trading on its ethos of natural beauty, Pixi makeup and skin-care line combines innovative formulas with skin-loving properties.",
                             Price = 24,
                             Size = Size.XXXL,
                             Color = "Grey",
                             Gender = Gender.Female,
                             Brand = asos,
                             Category = makeup,
                             SizeAndFit = "Product size: 60 patches",
                             LookAfterMe = "Use enclosed spatula to lift and separate each patch\r\nApply onto clean, dry under-eye area and leave for 10 minutes",
                             AboutMe = "Skincare for your self-care routine\r\nLightweight gel texture\r\nAims to brighten, hydrate and energise the delicate eye area\r\nSuitable for all skin types",

                             ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/pixi-beautifeye-brightening-hydrogel-eye-mask-patches-30-pairs/14762450-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/pixi-beautifeye-brightening-hydrogel-eye-mask-patches-30-pairs/14762450-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/pixi-beautifeye-brightening-hydrogel-eye-mask-patches-30-pairs/14762450-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://www.asos.com/pixi/pixi-beautifeye-brightening-hydrogel-eye-mask-patches-30-pairs/prd/14762450#colourWayId-16642113").Result
                            }
                        }
                         },
                          new ProductEntity
                          {

                              Name = "Embryolisse Lait Creme Concentrate Nourishing Moisturiser 75ml",
                              Description = "Founded by a dermatologist in 1950s Paris, Embryolisse Laboratoires put the care into skincare.",
                              Price = 24,
                              Size = Size.XXXL,
                              Color = "Grey",
                              Gender = Gender.Female,
                              Brand = asos,
                              Category = makeup,
                              SizeAndFit = "Product size: 75ml",
                              LookAfterMe = "Use AM and PM after cleansing and toning",
                              AboutMe = "Hydration station\r\nA rich moisturising lotion\r\nSuitable for use as a primer, moisturiser and make-up remover\r\nAccelerates cell renewal",

                              ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/embryolisse-lait-creme-concentrate-nourishing-moisturiser-75ml/7231933-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/embryolisse-lait-creme-concentrate-nourishing-moisturiser-75ml/7231933-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/embryolisse-lait-creme-concentrate-nourishing-moisturiser-75ml/7231933-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/embryolisse-lait-creme-concentrate-nourishing-moisturiser-75ml/7231933-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                          },
                           new ProductEntity
                           {

                               Name = "L'Oreal Paris Elvive Glycolic Gloss Shampoo for Dull Porous Hair 200ml",
                               Description = "Founded by a dermatologist in 1950s Paris, Embryolisse Laboratoires put the care into skincare.",
                               Price = 14,
                               Size = Size.XXXL,
                               Color = "Grey",
                               Gender = Gender.Female,
                               Brand = asos,
                               Category = makeup,
                               SizeAndFit = "Product size: 200ml",
                               LookAfterMe = "Massage into wet hair\r\nRinse well with warm water to remove\r\nFollow with a conditioner",
                               AboutMe = "For washing your hair, or when you need an excuse to stay in\r\nGlossing shampoo\r\nDesigned to help improve shine, smoothness and strength.",

                               ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-shampoo-for-dull-porous-hair-200ml/205975067-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-shampoo-for-dull-porous-hair-200ml/205975067-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-shampoo-for-dull-porous-hair-200ml/205975067-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-shampoo-for-dull-porous-hair-200ml/205975067-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                           },
                           new ProductEntity
                           {

                               Name = "L'Oreal Paris Elvive Glycolic Gloss Shampoo for Dull Porous Hair 200ml",
                               Description = "Founded by a dermatologist in 1950s Paris, Embryolisse Laboratoires put the care into skincare.",
                               Price = 14,
                               Size = Size.XXXL,
                               Color = "Grey",
                               Gender = Gender.Female,
                               Brand = asos,
                               Category = makeup,
                               SizeAndFit = "Product size: 200ml",
                               LookAfterMe = "Massage into wet hair\r\nRinse well with warm water to remove\r\nFollow with a conditioner",
                               AboutMe = "For washing your hair, or when you need an excuse to stay in\r\nGlossing shampoo\r\nDesigned to help improve shine, smoothness and strength.",

                               ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-shampoo-for-dull-porous-hair-200ml/205975067-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-shampoo-for-dull-porous-hair-200ml/205975067-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-shampoo-for-dull-porous-hair-200ml/205975067-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-shampoo-for-dull-porous-hair-200ml/205975067-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                           },
                             new ProductEntity
                             {

                                 Name = "NUXE Reve de Miel Honey Lip Care",
                                 Description = "French pharmacy staple Nuxe has positioned itself in the hearts (and bathroom cabinets) of beauty-lovers worldwide",
                                 Price = 17,
                                 Size = Size.XXXL,
                                 Color = "Grey",
                                 Gender = Gender.Female,
                                 Brand = asos,
                                 Category = makeup,
                                 SizeAndFit = "Product size: 10ml",
                                 LookAfterMe = "Apply the product to your lips using the applicator\r\nReapply as needed throughout the day",
                                 AboutMe = "Protect your pout\r\nTransparent lip oil\r\nDesigned to nourish lips\r\nIdeal for very dry lips",

                                 ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/nuxe-reve-de-miel-honey-lip-care/203924110-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/nuxe-reve-de-miel-honey-lip-care/203924110-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/nuxe-reve-de-miel-honey-lip-care/203924110-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/nuxe-reve-de-miel-honey-lip-care/203924110-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                             },
                             new ProductEntity
                             {

                                 Name = "LANEIGE Limited Edition Lip Sleeping Mask - Watermelon Pop",
                                 Description = "Refresh your routine with Korean skincare brand LANEIGE.",
                                 Price = 23,
                                 Size = Size.XXXL,
                                 Color = "Grey",
                                 Gender = Gender.Female,
                                 Brand = asos,
                                 Category = makeup,
                                 SizeAndFit = "Product size: 20g",
                                 LookAfterMe = "Apply to bare lips in the evening and leave on overnight\r\nWipe off lips in the morning",
                                 AboutMe = "Here's to hydrating\r\nOvernight lip mask\r\nDesigned to deliver intense moisture while you sleep\r\nBalm texture",

                                 ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/laneige-limited-edition-lip-sleeping-mask-watermelon-pop/207091130-1-watermelonpop?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/laneige-limited-edition-lip-sleeping-mask-watermelon-pop/207091130-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/laneige-limited-edition-lip-sleeping-mask-watermelon-pop/207091130-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/laneige-limited-edition-lip-sleeping-mask-watermelon-pop/207091130-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                             },
                              new ProductEntity
                              {

                                  Name = "Sol de Janeiro Cheirosa 76 Perfume Mist 240ml",
                                  Description = "Beauty brand Sol de Janeiro is all about combining Brazilian positivity with skin-loving ingredients to create its trending body butters, hair treatments and shower gels",
                                  Price = 40,
                                  Size = Size.XXXL,
                                  Color = "Grey",
                                  Gender = Gender.Female,
                                  Brand = asos,
                                  Category = makeup,
                                  SizeAndFit = "Product size: 240ml",
                                  LookAfterMe = "Spray onto pulse points and let it settle",
                                  AboutMe = "Switch up your scent\r\nInspired by the 1976 discotheque era of Brazil\r\nMidnight jasmine, blackcurrant and amber wood scented\r\nProduct is non-returnable for hygiene reasons",

                                  ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-cheirosa-76-perfume-mist-240ml/207067896-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-cheirosa-76-perfume-mist-240ml/207067896-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-cheirosa-76-perfume-mist-240ml/207067896-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-cheirosa-76-perfume-mist-240ml/207067896-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                              },
                                new ProductEntity
                                {

                                    Name = "Hair Syrup Growsmary Thickening Pre-Wash Hair Oil 300ml",
                                    Description = "Prepare for the group chat to pop off after they spot Hair Syrup in your bathroom shelfie.",
                                    Price = 36,
                                    Size = Size.XXXL,
                                    Color = "Grey",
                                    Gender = Gender.Female,
                                    Brand = asos,
                                    Category = makeup,
                                    SizeAndFit = "Product size: 300ml",
                                    LookAfterMe = "Apply to dry hair from root to tip, as a pre-wash treatment",
                                    AboutMe = "Helping your hair go the distance\r\nThickening hair treatment\r\nDesigned to reduce hair loss and encouraging re-growth\r\nSuitable for thin hair types",

                                    ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hair-syrup-growsmary-thickening-pre-wash-hair-oil-300ml/204409926-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hair-syrup-growsmary-thickening-pre-wash-hair-oil-300ml/204409926-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hair-syrup-growsmary-thickening-pre-wash-hair-oil-300ml/204409926-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hair-syrup-growsmary-thickening-pre-wash-hair-oil-300ml/204409926-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                },
                                new ProductEntity
                                {

                                    Name = "Benefit Badgal Bang Rebel Brown Mascara",
                                    Description = "In 1976, sisters Jean and Jane Ford flipped a coin – heads they opened a deli, tails they opened a makeup store.",
                                    Price = 29,
                                    Size = Size.XXXL,
                                    Color = "Grey",
                                    Gender = Gender.Female,
                                    Brand = asos,
                                    Category = makeup,
                                    SizeAndFit = "Product size: 8.5g",
                                    LookAfterMe = "Apply mascara to lashes from root to tip\r\nOnce dry, reapply to build and achieve desired look",
                                    AboutMe = "That finishing touch\r\nVolumising effect\r\nSpike wand\r\nSmudge-proof, water-resistant and long-lasting formula",

                                    ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/benefit-badgal-bang-rebel-brown-mascara/206924749-1-rebelbrown?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/benefit-badgal-bang-rebel-brown-mascara/206924749-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/benefit-badgal-bang-rebel-brown-mascara/206924749-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/benefit-badgal-bang-rebel-brown-mascara/206924749-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                },
                                 new ProductEntity
                                 {

                                     Name = "The Ordinary Mini Glycolic Acid 7% Exfoliating Toner 100ml",
                                     Description = "When it comes to skincare, The Ordinary's science-driven approach is anything but *ordinary*.",
                                     Price = 9,
                                     Size = Size.XXXL,
                                     Color = "Grey",
                                     Gender = Gender.Female,
                                     Brand = asos,
                                     Category = skincare,
                                     SizeAndFit = "Product size: 100ml",
                                     LookAfterMe = "For PM use, once a day. After cleaning the skin, apply the formula to a cotton pad and sweep across the face and neck.",
                                     AboutMe = "Exclusive to ASOS\r\n7% Toning Solution that mildly exfoliates skin, aiming to gradually improve skin’s radiance, texture, and clarity with continued use.",

                                     ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/the-ordinary-mini-glycolic-acid-7-exfoliating-toner-100ml/205485653-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/the-ordinary-mini-glycolic-acid-7-exfoliating-toner-100ml/205485653-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/the-ordinary-mini-glycolic-acid-7-exfoliating-toner-100ml/205485653-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/the-ordinary-mini-glycolic-acid-7-exfoliating-toner-100ml/205485653-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                 },
                                 new ProductEntity
                                 {

                                     Name = "LANEIGE Lip Glowy Balm - Candy Cane",
                                     Description = "Refresh your routine with Korean skincare brand LANEIGE.",
                                     Price = 19,
                                     Size = Size.XXXL,
                                     Color = "Grey",
                                     Gender = Gender.Female,
                                     Brand = asos,
                                     Category = skincare,
                                     SizeAndFit = "Product size: 10g",
                                     LookAfterMe = "Apply to bare lips or layer over lipstick for a hydration boost",
                                     AboutMe = "An all-year-round essential\r\n2-in-1 balm and gloss\r\nEnriched with shea and murumuru butter to nourish the lips",

                                     ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/laneige-lip-glowy-balm-candy-cane/207252719-1-candycane?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/laneige-lip-glowy-balm-candy-cane/207252719-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/laneige-lip-glowy-balm-candy-cane/207252719-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/laneige-lip-glowy-balm-candy-cane/207252719-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                 },
                                 new ProductEntity
                                 {

                                     Name = "\r\ne.l.f. Skin Holy Hydration! Makeup Melting Cleansing Balm",
                                     Description = "Give your beauty bag the ultimate makeover with e.l.f.",
                                     Price = 10,
                                     Size = Size.XXXL,
                                     Color = "Grey",
                                     Gender = Gender.Female,
                                     Brand = asos,
                                     Category = skincare,
                                     SizeAndFit = "Product size: 56.5g",
                                     LookAfterMe = "Scoop out a dime-sized amount of cleansing balm\r\nMoisten fingertips and massage into the skin\r\nRinse with water or remove with a warm damp cleansing cloth",
                                     AboutMe = "That fresh-face feeling\r\nMelting cleanser\r\nDesigned to remove makeup without stripping the skin\r\nSuitable for all skin types",

                                     ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/elf-skin-holy-hydration-makeup-melting-cleansing-balm/202523773-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/elf-skin-holy-hydration-makeup-melting-cleansing-balm/202523773-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/elf-skin-holy-hydration-makeup-melting-cleansing-balm/202523773-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/elf-skin-holy-hydration-makeup-melting-cleansing-balm/202523773-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                 },
                                 new ProductEntity
                                 {

                                     Name = "Garnier Micellar Cleansing Water Sensitive Skin 400ml",
                                     Description = "Swipe outwards from the centre of your face to remove facial makeup",
                                     Price = 8,
                                     Size = Size.XXXL,
                                     Color = "Grey",
                                     Gender = Gender.Female,
                                     Brand = asos,
                                     Category = skincare,
                                     SizeAndFit = "Product size: 400ml",
                                     LookAfterMe = "Soak a cotton pad with the remover\r\nPlace pad over the lid and hold down for 10 seconds to melt-away makeup",
                                     AboutMe = "A win for skin\r\nCleansing water\r\nAims to remove makeup, cleanse and soothe the skin\r\nSuitable for sensitive skin",

                                     ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/garnier-micellar-cleansing-water-sensitive-skin-400ml/12349780-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/garnier-micellar-cleansing-water-sensitive-skin-400ml/12349780-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/garnier-micellar-cleansing-water-sensitive-skin-400ml/12349780-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/garnier-micellar-cleansing-water-sensitive-skin-400ml/12349780-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                 },
                                 new ProductEntity
                                 {

                                     Name = "Caudalie Beauty Elixir 100ml",
                                     Description = "Step-up your skincare routine with our Caudalie at ASOS edit.",
                                     Price = 36,
                                     Size = Size.XXXL,
                                     Color = "Grey",
                                     Gender = Gender.Female,
                                     Brand = asos,
                                     Category = skincare,
                                     SizeAndFit = "Product size: 100ml",
                                     LookAfterMe = "Shake before use\r\nClose your eyes and spritz onto your face",
                                     AboutMe = "Next stop: checkout\r\nAims to provide an instant radiance boost for the complexion, whilst tightening the pores and smoothing fine lines and makeup creases",

                                     ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/caudalie-beauty-elixir-100ml/202549666-1-100ml?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/caudalie-beauty-elixir-100ml/202549666-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/caudalie-beauty-elixir-100ml/202549666-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/caudalie-beauty-elixir-100ml/202549666-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                 },
                                 new ProductEntity
                                 {

                                     Name = "Revolution Skincare 2% Salicylic Acid & Zinc Bha Anti Blemish Cleanser 150ml",
                                     Description = "Created in 2013 around the founder’s kitchen table, Revolution Skincare is committed to making vegan makeup and skincare that’s accessible to all.",
                                     Price = 6,
                                     Size = Size.XXXL,
                                     Color = "Grey",
                                     Gender = Gender.Female,
                                     Brand = asos,
                                     Category = skincare,
                                     SizeAndFit = "Product size: 150ml",
                                     LookAfterMe = "Give your skin some air time",
                                     AboutMe = "Facial cleanser\r\nDesigned to cleanse and balance skin, while preventing blemishes and locking in moisture",

                                     ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/revolution-skincare-2-salicylic-acid-zinc-bha-anti-blemish-cleanser-150ml/203602621-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/revolution-skincare-2-salicylic-acid-zinc-bha-anti-blemish-cleanser-150ml/203602621-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/revolution-skincare-2-salicylic-acid-zinc-bha-anti-blemish-cleanser-150ml/203602621-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/revolution-skincare-2-salicylic-acid-zinc-bha-anti-blemish-cleanser-150ml/203602621-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                 },
                                 new ProductEntity
                                 {

                                     Name = "Revolution Skincare Glitter Hyaluronic Acid Hydrating Eye Patches 30 Pairs",
                                     Description = "Created in 2013 around the founder’s kitchen table, Revolution is committed to making vegan makeup and skincare that’s accessible to all.",
                                     Price = 15,
                                     Size = Size.XXXL,
                                     Color = "Grey",
                                     Gender = Gender.Female,
                                     Brand = asos,
                                     Category = skincare,
                                     SizeAndFit = "60 x Revolution Glitter Hyaluronic Acid Hydrating Undereye Patches",
                                     LookAfterMe = "Use the enclosed spatula to gently lift and separate a delicate gel patch",
                                     AboutMe = "TLC for tired eyes\r\nHydrating undereye patches\r\nGlitter design",

                                     ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/revolution-skincare-glitter-hyaluronic-acid-hydrating-eye-patches-30-pairs/201480504-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/revolution-skincare-glitter-hyaluronic-acid-hydrating-eye-patches-30-pairs/201480504-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/revolution-skincare-glitter-hyaluronic-acid-hydrating-eye-patches-30-pairs/201480504-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/revolution-skincare-glitter-hyaluronic-acid-hydrating-eye-patches-30-pairs/201480504-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                 },
                                  new ProductEntity
                                  {

                                      Name = "Cetaphil Oily Skin Cleanser Combination Skin 473ml",
                                      Description = "Serving up no-nonsense skincare for over 70 years, Cetaphil is here to help you cleanse, hydrate and protect your skin.",
                                      Price = 16,
                                      Size = Size.XXXL,
                                      Color = "Grey",
                                      Gender = Gender.Female,
                                      Brand = asos,
                                      Category = skincare,
                                      SizeAndFit = "Product size: 473ml",
                                      LookAfterMe = "Apply to damp skin\r\nMassage over face in circular motions\r\nRinse with warm water and pat dry with a towel",
                                      AboutMe = "Give your skin some air time\r\nFoaming cleanser\r\nDesigned to wash away dirt, unclog pores and remove makeup",

                                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cetaphil-oily-skin-cleanser-combination-skin-473ml/203267257-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cetaphil-oily-skin-cleanser-combination-skin-473ml/203267257-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cetaphil-oily-skin-cleanser-combination-skin-473ml/203267257-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cetaphil-oily-skin-cleanser-combination-skin-473ml/203267257-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                  },
                                  new ProductEntity
                                  {

                                      Name = "COSRX Advanced Snail 92 All in one Cream 100ml",
                                      Description = "Formulated with 92% snail secretion filtrate to calm, regenerate and repair skin.",
                                      Price = 33,
                                      Size = Size.XXXL,
                                      Color = "Grey",
                                      Gender = Gender.Female,
                                      Brand = asos,
                                      Category = skincare,
                                      SizeAndFit = "Product size: 100ml",
                                      LookAfterMe = "Apply in the AM and PM after toning \r\nAvoid the eye and mouth area\r\nPress residue in with your fingertips to aid absorption",
                                      AboutMe = "Hydration station\r\nNourishing cream \r\nDesigned to prevent breakouts and maintain skin elasticity\r\nGel-like texture",

                                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cosrx-advanced-snail-92-all-in-one-cream-100ml/201917857-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cosrx-advanced-snail-92-all-in-one-cream-100ml/201917857-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cosrx-advanced-snail-92-all-in-one-cream-100ml/201917857-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cosrx-advanced-snail-92-all-in-one-cream-100ml/201917857-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                  },
                                  new ProductEntity
                                  {

                                      Name = "Glow Hub The Scar Slayer Anti-Pigmentation & Scar-Minimising Acid Serum 30ml",
                                      Description = "Glow Hub believes that healthy, happy skin isn’t just a trend, and we agree.",
                                      Price = 15,
                                      Size = Size.XXXL,
                                      Color = "Grey",
                                      Gender = Gender.Female,
                                      Brand = asos,
                                      Category = skincare,
                                      SizeAndFit = "Product size: 30ml",
                                      LookAfterMe = "Apply a few drops to cleansed skin\r\nMassage and leave to soak in\r\nFollow with a moisturiser",
                                      AboutMe = "Face + Body by Glow Hub",

                                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/glow-hub-the-scar-slayer-anti-pigmentation-scar-minimising-acid-serum-30ml/201269227-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/glow-hub-the-scar-slayer-anti-pigmentation-scar-minimising-acid-serum-30ml/201269227-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/glow-hub-the-scar-slayer-anti-pigmentation-scar-minimising-acid-serum-30ml/201269227-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/glow-hub-the-scar-slayer-anti-pigmentation-scar-minimising-acid-serum-30ml/201269227-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                  },
                                  new ProductEntity
                                  {

                                      Name = "Eco Style Olive Oil Styling Gel Green 236ml",
                                      Description = "Eco Style makes beauty affordable as it believes its power should be accessible (ICYDK: eco = economical).",
                                      Price = 6,
                                      Size = Size.XXXL,
                                      Color = "Grey",
                                      Gender = Gender.Female,
                                      Brand = asos,
                                      Category = haircare,
                                      SizeAndFit = "Product size: 236 ml",
                                      LookAfterMe = "Apply gel to dry or damp hair\r\nWork chosen amount through hair and style as desired",
                                      AboutMe = "Face + Body by Eco Style",

                                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/eco-style-olive-oil-styling-gel-green-236ml/201788889-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/eco-style-olive-oil-styling-gel-green-236ml/201788889-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/eco-style-olive-oil-styling-gel-green-236ml/201788889-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/eco-style-olive-oil-styling-gel-green-236ml/201788889-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                  },
                                  new ProductEntity
                                  {

                                      Name = "\r\nL'Oreal Paris Elvive Glycolic Gloss, 5 Minute Lamination Treatment for Dull Porous Hair 200ml",
                                      Description = "With an approach grounded in science, leading beauty brand L'Oreal Elvive demands only the most visionary products from its team",
                                      Price = 17,
                                      Size = Size.XXXL,
                                      Color = "Grey",
                                      Gender = Gender.Female,
                                      Brand = asos,
                                      Category = haircare,
                                      SizeAndFit = "Product size: 150ml",
                                      LookAfterMe = "After conditioner, apply a generous amount on damp hair from lengths to tips\r\nLeave on for 5 minutes and then rinse thoroughly",
                                      AboutMe = "Helping your hair go the distance\r\nTargets dull hair to boost shine\r\nSuitable for all hair types",

                                      ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-5-minute-lamination-treatment-for-dull-porous-hair-200ml/205975064-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-5-minute-lamination-treatment-for-dull-porous-hair-200ml/205975064-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-5-minute-lamination-treatment-for-dull-porous-hair-200ml/205975064-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-glycolic-gloss-5-minute-lamination-treatment-for-dull-porous-hair-200ml/205975064-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                  },
                                   new ProductEntity
                                   {

                                       Name = "Mielle Rosemary Mint Scalp & Hair Strengthening Oil 59ml",
                                       Description = "Tame your mane with haircare from our Mielle at ASOS edit.",
                                       Price = 12,
                                       Size = Size.XXXL,
                                       Color = "Grey",
                                       Gender = Gender.Female,
                                       Brand = asos,
                                       Category = haircare,
                                       SizeAndFit = "Product size: 59ml",
                                       LookAfterMe = "Apply a small amount of oil to scalp and massage in with fingers and comb through to ends of hair\r\nLeave in and style as desired",
                                       AboutMe = "Your hair will thank you\r\nStrengthening hair and scalp oil\r\nDesigned to promote hair growth, nourish hair follicles, smooth split ends and prevent dry scalp",

                                       ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/mielle-rosemary-mint-scalp-hair-strengthening-oil-59ml/206571545-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/mielle-rosemary-mint-scalp-hair-strengthening-oil-59ml/206571545-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/mielle-rosemary-mint-scalp-hair-strengthening-oil-59ml/206571545-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/mielle-rosemary-mint-scalp-hair-strengthening-oil-59ml/206571545-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                   },
                                   new ProductEntity
                                   {

                                       Name = "Cantu Shea Butter For Natural Hair Wave Whip Curling Mousse 248 ml",
                                       Description = "When it comes to textured hair, Cantu is your go-to brand – but you probably already knew that.",
                                       Price = 8,
                                       Size = Size.XXXL,
                                       Color = "Grey",
                                       Gender = Gender.Female,
                                       Brand = asos,
                                       Category = haircare,
                                       SizeAndFit = "Product size: 248ml",
                                       LookAfterMe = "Apply to wet hair, then scrunch upward toward the scalp, hold and release\r\nAllow hair to air dry or diffuse",
                                       AboutMe = "The final step of your hair-care routine\r\nHelps create crunch-free waves and curls\r\nAnti-frizz finish\r\nAims to add volume",

                                       ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cantu-shea-butter-for-natural-hair-wave-whip-curling-mousse-248-ml/14838777-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cantu-shea-butter-for-natural-hair-wave-whip-curling-mousse-248-ml/14838777-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cantu-shea-butter-for-natural-hair-wave-whip-curling-mousse-248-ml/14838777-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cantu-shea-butter-for-natural-hair-wave-whip-curling-mousse-248-ml/14838777-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                   },
                                    new ProductEntity
                                    {

                                        Name = "\r\nBeauty Works 10 in 1 Miracle Spray 250ml",
                                        Description = "Creating simple and effective solutions for all hair types, discover Beauty Works' range of products and tools",
                                        Price = 13,
                                        Size = Size.XXXL,
                                        Color = "Grey",
                                        Gender = Gender.Female,
                                        Brand = asos,
                                        Category = haircare,
                                        SizeAndFit = "Product size: 250ml",
                                        LookAfterMe = "Spray onto damp or dry hair \r\nStyle as desired with hot tools",
                                        AboutMe = "Cue slo-mo hair flicks \r\nMultipurpose hair treatment\r\nDesigned to help nourish, repair and protect your hair during heat styling \r\nArgan and macadamia extracts work to reduce frizz, restore lost oils, add shine and prevent split ends ",

                                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/beauty-works-10-in-1-miracle-spray-250ml/20792423-1-miraclespray?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/beauty-works-10-in-1-miracle-spray-250ml/20792423-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/beauty-works-10-in-1-miracle-spray-250ml/20792423-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/beauty-works-10-in-1-miracle-spray-250ml/20792423-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                    },
                                    new ProductEntity
                                    {

                                        Name = "\r\nCantu Shea Butter Moisturizing Curl Activator Cream 355ml",
                                        Description = "When it comes to textured hair, Cantu is your go-to brand – but you probably already knew that.",
                                        Price = 9,
                                        Size = Size.XXXL,
                                        Color = "Grey",
                                        Gender = Gender.Female,
                                        Brand = asos,
                                        Category = haircare,
                                        SizeAndFit = "Product size: 355ml",
                                        LookAfterMe = "Apply to damp hair section by section\r\nReapply to dry hair as needed for additional moisture",
                                        AboutMe = "Cos your hair deserves good things\r\nRich texture\r\nAims to smooth and enhance your natural curls\r\nFor frizz-free volume ",

                                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cantu-shea-butter-moisturizing-curl-activator-cream-355ml/12606563-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cantu-shea-butter-moisturizing-curl-activator-cream-355ml/12606563-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cantu-shea-butter-moisturizing-curl-activator-cream-355ml/12606563-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/cantu-shea-butter-moisturizing-curl-activator-cream-355ml/12606563-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                    },
                                    new ProductEntity
                                    {

                                        Name = "Hair Syrup Rapunzel Growth Pre-Wash Hair Oil 100ml",
                                        Description = "Prepare for the group chat to pop off after they spot Hair Syrup in your bathroom shelfie.",
                                        Price = 16,
                                        Size = Size.XXXL,
                                        Color = "Grey",
                                        Gender = Gender.Female,
                                        Brand = asos,
                                        Category = haircare,
                                        SizeAndFit = "Product size: 100ml",
                                        LookAfterMe = "Apply to dry hair from roots to ends\r\nGently massage into scalp\r\nLeave in for for at least 1 hour\r\nRinse well with warm water to remove\r\nStyle as desired",
                                        AboutMe = "Helping your hair go the distance\r\nPre-wash hair oil\r\nDesigned to nourish hair and promote growth ",

                                        ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hair-syrup-rapunzel-growth-pre-wash-hair-oil-100ml/204409911-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hair-syrup-rapunzel-growth-pre-wash-hair-oil-100ml/204409911-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hair-syrup-rapunzel-growth-pre-wash-hair-oil-100ml/204409911-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hair-syrup-rapunzel-growth-pre-wash-hair-oil-100ml/204409911-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                    },
                                     new ProductEntity
                                     {

                                         Name = "MONDAY Haircare Volume Shampoo 350ml",
                                         Description = "Hair-wash day just got interesting. Specialising in luxe, salon-quality hair-care products formulated with natural ingredients",
                                         Price = 6,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = haircare,
                                         SizeAndFit = "Product size: 350ml",
                                         LookAfterMe = "Massage into wet hair\r\nRinse well with warm water to remove\r\nFollow with a conditioner",
                                         AboutMe = "For washing your hair, or when you need an excuse to stay in\r\nVolumising shampoo\r\nDesigned to cleanse hair while adding body\r\nLightweight texture ",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/monday-haircare-volume-shampoo-350ml/203970617-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/monday-haircare-volume-shampoo-350ml/203970617-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/monday-haircare-volume-shampoo-350ml/203970617-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/monday-haircare-volume-shampoo-350ml/203970617-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "Curlsmith Double Cream Deep Quencher 237ml",
                                         Description = "Give your coils the care they crave with Curlsmith.",
                                         Price = 26,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = haircare,
                                         SizeAndFit = "Product size: 237ml",
                                         LookAfterMe = "Apply to wet hair from root to tip\r\nFor a quick moisturising boost leave on for 10-15 minutes\r\nFor a deep moisturising treatment leave on for 30 minutes",
                                         AboutMe = "Look after your locks\r\nNourishing curl cream\r\nDesigned to help condition and enhance hair \r\nIdeal for dry and dull hair types  ",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/curlsmith-double-cream-deep-quencher-237ml/203038771-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/curlsmith-double-cream-deep-quencher-237ml/203038771-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/curlsmith-double-cream-deep-quencher-237ml/203038771-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/curlsmith-double-cream-deep-quencher-237ml/203038771-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "L'Oreal Paris Elvive Hydra Pure 72h Rehydrating Conditioner 400ml",
                                         Description = "With an approach grounded in science, leading beauty brand L'Oreal Elvive demands only the most visionary products from its team.",
                                         Price = 8,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = haircare,
                                         SizeAndFit = "Product size: 400ml",
                                         LookAfterMe = "Apply to damp hair after shampooing\r\nMassage through mid-lengths and ends, avoiding the roots\r\nLeave in for a few minutes\r\nRinse with warm water to remove",
                                         AboutMe = "The best part of ‘hair-wash day’\r\nHydrating conditioner\r\nDesigned to rehydrate hair\r\nIdeal for oily scalp, roots and dry lengths\r\nSuitable for all hair types  ",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-hydra-pure-72h-rehydrating-conditioner-400ml/205963536-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-hydra-pure-72h-rehydrating-conditioner-400ml/205963536-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-hydra-pure-72h-rehydrating-conditioner-400ml/205963536-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/loreal-paris-elvive-hydra-pure-72h-rehydrating-conditioner-400ml/205963536-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "Shay & Blue Black Tulip Natural Spray Fragrance EDP 10ml",
                                         Description = "Well, this is exciting. We’ve teamed up with award-winning London perfumery Shay & Blue and put together an edit of its dreamy",
                                         Price = 23,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 10ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle",
                                         AboutMe = "Your new signature scent\r\nExpect fresh florals, fruity plum, smooth chocolate and woods\r\nTop notes: Snowdrops, Cyclamen\r\nHeart notes: Black Tulip, Plum",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-black-tulip-natural-spray-fragrance-edp-10ml/10681036-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-black-tulip-natural-spray-fragrance-edp-10ml/10681036-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-black-tulip-natural-spray-fragrance-edp-10ml/10681036-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-black-tulip-natural-spray-fragrance-edp-10ml/10681036-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "Shay & Blue Atropa Belladonna Natural Spray Fragrance EDP 100ml",
                                         Description = "Well, this is exciting. We’ve teamed up with award-winning London perfumery Shay & Blue and put together an edit of its dreamy",
                                         Price = 58,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 100ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle",
                                         AboutMe = "Your new signature scent\r\nExpect fresh florals, fruity plum, smooth chocolate and woods\r\nTop notes: Snowdrops, Cyclamen\r\nHeart notes: Black Tulip, Plum",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-atropa-belladonna-natural-spray-fragrance-edp-100ml/11606355-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-atropa-belladonna-natural-spray-fragrance-edp-100ml/11606355-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-atropa-belladonna-natural-spray-fragrance-edp-100ml/11606355-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-atropa-belladonna-natural-spray-fragrance-edp-100ml/11606355-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "Shay & Blue Framboise Noire Natural Spray Fragrance EDP 10ml",
                                         Description = "Well, this is exciting. We’ve teamed up with award-winning London perfumery Shay & Blue and put together an edit of its dreamy",
                                         Price = 23,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 10ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle",
                                         AboutMe = "Your new signature scent\r\nExpect fresh florals, fruity plum, smooth chocolate and woods\r\nTop notes: Snowdrops, Cyclamen\r\nHeart notes: Black Tulip, Plum",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-framboise-noire-natural-spray-fragrance-edp-10ml/11606348-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-framboise-noire-natural-spray-fragrance-edp-10ml/11606348-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-framboise-noire-natural-spray-fragrance-edp-10ml/11606348-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/shay-blue-framboise-noire-natural-spray-fragrance-edp-10ml/11606348-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "BOSS Bottled Night Eau de Toilette 100ml",
                                         Description = "If you need an excuse for a wardrobe update, HUGO BOSS Fragrances is it.",
                                         Price = 89,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 100ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle",
                                         AboutMe = "Woody, aromatic fragrance\r\nIntense and spicy\r\nTop Notes: Bitter birch leaves, Aromatic lavender, Citric lemon leaves",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-bottled-night-eau-de-toilette-100ml/200394648-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-bottled-night-eau-de-toilette-100ml/200394648-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-bottled-night-eau-de-toilette-100ml/200394648-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-bottled-night-eau-de-toilette-100ml/200394648-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "BOSS The Scent For Him Eau de Toilette 50ml",
                                         Description = "If you need an excuse for a wardrobe update, HUGO BOSS Fragrances is it.",
                                         Price = 66,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 50ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle\r\n\r\nTop notes: Ginger\r\nHeart notes: Maninka fruit\r\nBase notes: Leather accords",
                                         AboutMe = "Your new signature scent \r\nWarm, aromatic and clean\r\nInspired by sensuality and seduction \r\nExpect aromatic ginger and rich leathers",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-the-scent-for-him-eau-de-toilette-50ml/200394621-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-the-scent-for-him-eau-de-toilette-50ml/200394621-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-the-scent-for-him-eau-de-toilette-50ml/200394621-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-the-scent-for-him-eau-de-toilette-50ml/200394621-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "BOSS Femme For Her Eau de Parfum 75ml",
                                         Description = "If you need an excuse for a wardrobe update, HUGO BOSS Fragrances is it.",
                                         Price = 83,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 75ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle\r\n\r\nTop notes: Tangerine, blackcurrant Buds and freesia\r\nHeart notes: Lily, staphanotis and rose petal\r\nBase notes: Musky notes, apricot and satinwood",
                                         AboutMe = "Who doesn’t want to smell this good?\r\nRadiant, soft and smooth\r\nExudes an aura of captivating femininity\r\nExpect notes of rose, jasmine and ylang-ylang",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-femme-for-her-eau-de-parfum-75ml/200394598-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-femme-for-her-eau-de-parfum-75ml/200394598-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-femme-for-her-eau-de-parfum-75ml/200394598-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-femme-for-her-eau-de-parfum-75ml/200394598-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "Sol de Janeiro Brazilian Crush Cheirosa 62 Perfume Mist 240ml",
                                         Description = "Beauty brand Sol de Janeiro is all about combining Brazilian positivity with skin-loving ingredients to create its trending body butters",
                                         Price = 40,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 240ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle",
                                         AboutMe = "The scroll is over\r\nFragrance mist\r\nTop notes: Pistachio and almond\r\nHeart notes: Heliotrope and jasmine petals",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-brazilian-crush-cheirosa-62-perfume-mist-240ml/202840786-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-brazilian-crush-cheirosa-62-perfume-mist-240ml/202840786-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-brazilian-crush-cheirosa-62-perfume-mist-240ml/202840786-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-brazilian-crush-cheirosa-62-perfume-mist-240ml/202840786-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "Sol de Janeiro Brazilian Crush Cheirosa 40 Bom Dia Bright Perfume Mist 90ml",
                                         Description = "Beauty brand Sol de Janeiro is all about combining Brazilian positivity with skin-loving ingredients to create its trending body butters",
                                         Price = 26,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 90ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle",
                                         AboutMe = "Your new signature scent\r\nFragrance mist\r\nSuitable for hair, body and clothing\r\nTop notes: Black Amber Plum and Crème de Cassis",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-brazilian-crush-cheirosa-40-bom-dia-bright-perfume-mist-90ml/202840762-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-brazilian-crush-cheirosa-40-bom-dia-bright-perfume-mist-90ml/202840762-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-brazilian-crush-cheirosa-40-bom-dia-bright-perfume-mist-90ml/202840762-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/sol-de-janeiro-brazilian-crush-cheirosa-40-bom-dia-bright-perfume-mist-90ml/202840762-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                     new ProductEntity
                                     {

                                         Name = "HUGO Man Eau de Toilette 125ml",
                                         Description = "If you need an excuse for a wardrobe update, HUGO BOSS Fragrances is it.",
                                         Price = 76,
                                         Size = Size.XXXL,
                                         Color = "Grey",
                                         Gender = Gender.Female,
                                         Brand = asos,
                                         Category = perfume,
                                         SizeAndFit = "Product size: 125ml",
                                         LookAfterMe = "Spray onto pulse points and let it settle",
                                         AboutMe = "Your new signature scent\r\nClean, fresh, herby\r\nTop notes: Green apple\r\nHeart notes: Aromatic notes",

                                         ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hugo-man-eau-de-toilette-125ml/200394633-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hugo-man-eau-de-toilette-125ml/200394633-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hugo-man-eau-de-toilette-125ml/200394633-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/hugo-man-eau-de-toilette-125ml/200394633-4?$n_320w$&wid=317&fit=constrain").Result
                            }
                        }
                                     },
                                       new ProductEntity
                                       {

                                           Name = "BOSS The Scent Magnetic Eau de Parfum for Women 30ml",
                                           Description = "A leader in luxury fashion, HUGO BOSS Fragrances range of investment-worthy clothing and accessories hits different.",
                                           Price = 74,
                                           Size = Size.XXXL,
                                           Color = "Grey",
                                           Gender = Gender.Female,
                                           Brand = asos,
                                           Category = perfume,
                                           SizeAndFit = "Product size: 30ml",
                                           LookAfterMe = "Spray onto pulse points and let it settle",
                                           AboutMe = "Your new signature scent\r\nExciting and attractive\r\nTop notes: osmanthus\r\nHeart notes: ambrette and musk",

                                           ProductImages = new List<ProductImageEntity>
                        {
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-the-scent-magnetic-eau-de-parfum-for-women-30ml/204544152-1-nocolour?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-the-scent-magnetic-eau-de-parfum-for-women-30ml/204544152-2?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-the-scent-magnetic-eau-de-parfum-for-women-30ml/204544152-3?$n_320w$&wid=317&fit=constrain").Result
                            },
                            new ProductImageEntity
                            {
                                ImagePath = imageWorker.SaveFotoProduct("https://images.asos-media.com/products/boss-the-scent-magnetic-eau-de-parfum-for-women-30ml/204544152-4?$n_320w$&wid=317&fit=constrain").Result
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


