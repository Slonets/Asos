using Core.DTO.Authentication;
using Core.DTO.Site.Basket;
using Core.DTO.Site.Product;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities.Location;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Services
{
    public class OrderService:IOrderService
    {
        private readonly IRepository<OrderService> _orderEntity;
        private readonly AsosDbContext _context;
        public OrderService(IRepository<OrderService> orderEntity, AsosDbContext context)
        {
            _orderEntity=orderEntity;
            _context=context;
        }

        public async Task<PagedResult<OrderInformationDto>> GetInfarmationAboutOrder(int idUser, int pageNumber, int pageSize)
        {
            var orders = _context.Orders
         .Where(order => order.UserId == idUser)
         .Select(order => new OrderInformationDto
         {
             Id = order.Id,
             Status = order.OrderStatus.Name,
             Names = order.OrderProducts.Select(op => op.Product.Name).ToList(),
             TotalPrice = order.Amount,
             ImagePaths = order.OrderProducts
             .SelectMany(op => op.Product.ProductImages
             .Select(img => img.ImagePath)).ToList()
         });

            // Загальна кількість користувачів
            var totalOrders = await orders.CountAsync();

            // Повернення користувачів для конкретної сторінки
            var items = await orders
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<OrderInformationDto>
            {
                Items = items,
                TotalCount = totalOrders,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };

        }

        public async Task<PagedResult<BasketViewItem>> GetOrderById(int id, int pageNumber, int pageSize)
        {
            var orders = _context.Orders
       .Where(x => x.Id == id)
       .Include(x => x.OrderProducts)
           .ThenInclude(op => op.Product) // Приєднуємо продукти до OrderProducts
       .SelectMany(order => order.OrderProducts.Select(op => new BasketViewItem
       {
           Id = op.Product.Id,
           Name = op.Product.Name,
           Description = op.Product.Description,
           Price = op.Price, 
           Color = op.Product.Color,
           Brand = op.Product.Brand.Name, 
           Category = op.Product.Category.Name,
           Gender = op.Product.Gender,
           LookAfterMe = op.Product.LookAfterMe,
           AboutMe = op.Product.AboutMe,
           SizeAndFit = op.Product.SizeAndFit,
           Amount = op.Count, 
           ImagePaths = op.Product.ProductImages.Select(pi => pi.ImagePath).ToList() // Припускаємо, що ProductImage має поле ImagePath
       }));


            // Загальна кількість користувачів
            var totalOrders = await orders.CountAsync();

            // Повернення користувачів для конкретної сторінки
            var items = await orders
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<BasketViewItem>
            {
                Items = items,
                TotalCount = totalOrders,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
           
        }
    }
}
