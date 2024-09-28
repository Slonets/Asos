using Core.DTO.Authentication;
using Core.DTO.Site.Basket;
using Core.DTO.Site.Product;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities.Enums;
using Infrastructure.Entities.Location;
using Infrastructure.Entities.Site;
using Infrastructure.Interfaces;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Services
{
    public class BasketService : IBasketService
    {

        private readonly IRepository<BasketEntity> _basket;
        private readonly IRepository<ProductEntity> _product;
        private readonly IRepository<OrderStatusEntity> _status;
        private readonly AsosDbContext _context;

        public BasketService(IRepository<OrderStatusEntity> status, IRepository<BasketEntity> basket, IRepository<ProductEntity> product, AsosDbContext context) 
        {
            _basket = basket;
            _product = product;
            _context = context;
            _status= status;
        }

        public async Task pushBasketById(int idUser, int productId)
        {
        
            var product = await _product.GetByIDAsync(productId);

            var searh = await _basket.GetAsync();

            var existingBasketItem = searh.FirstOrDefault(b => b.ProductId == product.Id && b.UserId == idUser);

            if (existingBasketItem == null)
            {
                // Якщо товар не знайдено в кошику, додаємо новий
                await _basket.InsertAsync(new BasketEntity
                {
                    ProductId = product.Id,
                    UserId = idUser,
                    DateAdded = DateTime.UtcNow
                });

                await _basket.SaveAsync();
            }
        }
        public async Task pushBasketArray(int userId, int[] productIds)
        {
            // Отримуємо всі товари
            var items = await _product.GetAsync();
            var products = items.ToArray();

            // Отримуємо всі товари в кошику
            var baskets = await _basket.GetAsync();

            // Фільтруємо товари в кошику для конкретного користувача
            var existingBasketItems = baskets.Where(x => x.UserId == userId).ToList();

            // Список товарів для додавання у кошик
            List<ProductEntity> returnProduct = new List<ProductEntity>();

            // Для кожного ID продукту перевіряємо його наявність
            foreach (var productId in productIds)
            {
                var product = products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    returnProduct.Add(product);
                }
            }

            foreach (var product in returnProduct)
            {
                // Перевіряємо, чи вже є цей товар у кошику
                var existingItem = existingBasketItems.FirstOrDefault(b => b.ProductId == product.Id);
                if (existingItem == null)
                {
                    // Додаємо новий товар у кошик
                    await _basket.InsertAsync(new BasketEntity
                    {
                        ProductId = product.Id,
                        UserId = userId,
                        DateAdded = DateTime.UtcNow
                    });
                }
            }

            await _basket.SaveAsync();
        }

        public async Task<List<BasketViewItem>> GetBasketItems(int userId, int[]array)
        {
            List<BasketViewItem> items = await _context.Basket
            .Where(x => x.UserId == userId && array.Contains(x.ProductId))
            .Select(x => new BasketViewItem
            {
                Id= x.Product.Id,
                Name = x.Product.Name,
                Description = x.Product.Description,
                Price = x.Product.Price,
                Size = x.Product.Size,
                Color = x.Product.Color,
                Brand = x.Product.Brand.Name,
                Category = x.Product.Category.Name,
                Gender = x.Product.Gender,
                LookAfterMe = x.Product.LookAfterMe,
                AboutMe = x.Product.AboutMe,
                SizeAndFit = x.Product.SizeAndFit,
                Amount = 1,
                ImagePaths = x.Product.ProductImages.Select(pi => pi.ImagePath).ToList()
                }).ToListAsync();

            return items;
        }
        public async Task<List<BasketViewItem>> GetBasketItemsLogout(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return new List<BasketViewItem>();
            }

            List<BasketViewItem> items = await _context.Products
                .Where(x => array.Contains(x.Id))
                .Select(x => new BasketViewItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Size = x.Size,
                    Color = x.Color,
                    Brand = x.Brand.Name,
                    Category = x.Category.Name,
                    Gender = x.Gender,
                    LookAfterMe = x.LookAfterMe,
                    AboutMe = x.AboutMe,
                    SizeAndFit = x.SizeAndFit,
                    Amount = 1,
                    ImagePaths = x.ProductImages.Select(pi => pi.ImagePath).ToList()
                }).ToListAsync();

            return items;
        }
        
        public async Task<List<int>> DeleteProductWithBascet(int userId, int productId)
        {
            var basketItem = await _context.Basket.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);

            if (basketItem != null)
            {
                _context.Basket.Remove(basketItem);
                
                await _context.SaveChangesAsync();
            }

            List<int> array = await _context.Basket.Where(x => x.UserId == userId).Select(x => x.ProductId).ToListAsync();

            return array;
        }

        public async Task PushOrderWhenLogin(int userId, List<OrderItemDto> orderItems)
        {      

            var status = await _context.OrderStatus.Where(x => x.Name == "Booked").FirstOrDefaultAsync();

            var amount = orderItems.FirstOrDefault().Amount;

            var order = new OrderEntity
            { 
                UserId = userId , 
                OrderStatusId= status.Id,
                DateCrated= DateTime.UtcNow,
                Amount= amount
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();


            var listProduct = new List<OrderProductEntity>();
            
            foreach(var item in orderItems) 
            {
                listProduct.Add(
                    new OrderProductEntity
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Count=item.Count,
                        Price=item.Price
                    });
            }

            _context.OrderProducts.AddRange(listProduct);
            
            await _context.SaveChangesAsync();
        }
    }
}
