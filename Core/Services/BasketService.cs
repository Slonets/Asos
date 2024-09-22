using Core.DTO.Authentication;
using Core.Interfaces;
using Infrastructure.Entities.Location;
using Infrastructure.Entities.Site;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BasketService : IBasketService
    {

        private readonly IRepository<BasketEntity> _basket;
        private readonly IRepository<ProductEntity> _product;

        public BasketService(IRepository<BasketEntity> basket, IRepository<ProductEntity> product) 
        {
            _basket = basket;
            _product = product;
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

    }
}
