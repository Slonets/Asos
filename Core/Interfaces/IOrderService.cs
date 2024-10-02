using Core.DTO.Authentication;
using Core.DTO.Site.Basket;
using Core.DTO.Site.Product;
using MailKit.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<PagedResult<OrderInformationDto>> GetInfarmationAboutOrder(int idUser, int page, int pageSize);

        Task<PagedResult<BasketViewItem>> GetOrderById(int id, int pageNumber, int pageSize);
    }
}
