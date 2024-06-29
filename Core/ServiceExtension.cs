using Core.Interfaces;
using Core.Mapper;
using Core.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ServiceExtension
    {
        public static void AddCustomService(this IServiceCollection service)
        {            
            service.AddScoped<IJwtTokenService, JwtTokenService>();       
            service.AddScoped<IAccountService, AccountService>();       
            service.AddScoped<ISmtpEmailService, SmtpEmailService>();
            service.AddScoped<IFotoAvatar, FotoAvatar>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ISubCategoryService, SubCategoryService>();
            service.AddScoped<IBrandService, BrandServices>();
        }       
        public static void AddAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }       
    }
}
