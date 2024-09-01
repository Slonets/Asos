using Core.Constants;
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Entities.Site;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities.Enums;
using Infrastructure.Entities.Location;
using System;

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
                    new CategoryEntity { Id = 1, Name = "Clothing" },
                    new CategoryEntity { Id = 2, Name = "Sportswear" },
                    new CategoryEntity { Id = 3, Name = "Accessories" }
                    );
            }
            if (!context.SubCategories.Any())
            {
                context.SubCategories.AddRange(
                    new SubCategoryEntity { Name = "Shirts", CategoryId = 1 },
                    new SubCategoryEntity { Name = "Joggers", CategoryId = 2 },
                    new SubCategoryEntity { Name = "Rings", CategoryId = 3 }
                    );
            }
            /*  if (!context.Products.Any())
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
                      SizeAndFit = "Model's height: 188cm / 6' 2'', Model is wearing: M - 50",
                      LookAfterMe = "Machine wash according to instructions on care label",
                      AboutMe = "Linen: lightweight and strong, Main: 100% Linen."

                  },
                  new ProductEntity
                  {

                      Name = "adidas Football Entrada 22 joggers in black",
                      Description = "Win on and off the pitch, Inner drawcord waistband, Mid rise, Side pockets, adidas logo embroidery to thigh, Zip cuffs for easy changing over trainers ,Regular, tapered fit",
                      Price = 56,
                      Size = Size.L,
                      Color = "black",
                      Gender = Gender.Male,
                      SizeAndFit = "Model's height: 185cm/6'1, Model is wearing: Medium",
                      LookAfterMe = "Machine wash according to instructions on care label",
                      AboutMe = "Sweatshirt fabric: soft and warm, Main: 100% Polyester."

                  },
                   new ProductEntity
                   {

                       Name = "ASOS DESIGN waterproof stainless steel band ring with greek wave edge in gold tone",
                       Description = "Accessorising is the best part, Greek wave design, Slim band, Smooth finish, You can shower, swim and work out with me",
                       Price = 27,
                       Size = Size.L,
                       Color = "black",
                       Gender = Gender.Male,
                       SizeAndFit = "ICYDK your ring size: wrap a strip of paper tightly around your finger, marking where the paper meets. Then measure the length (in mm) between the mark and the end – find your closest size in the drop down.",
                       LookAfterMe = "Wipe clean with a soft dry cloth",
                       AboutMe = "Corrosion-resistant, non-tarnish stainless steel: gold plating, Main: 100% Steel."

                   }

               );*/
            context.SaveChanges();

            #endregion

                #region Adrees, Town, Country

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

            }
        }
    

    }
}


