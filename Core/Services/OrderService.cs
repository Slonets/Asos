using Core.DTO.Authentication;
using Core.DTO.Site.Basket;
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
    }
}
