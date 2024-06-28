using AutoMapper;
using Core.DTO.Site.Product;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities.Enums;
using Infrastructure.Entities.Site;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly AsosDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IMapper mapper, AsosDbContext asosDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _context = asosDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task Create(CreateProductDto model)
        {
           var product = _mapper.Map<ProductEntity>(model);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            if (model.ImageUrls != null && model.ImageUrls.Any())
            {
                var imgList = new List<ProductImageEntity>();
                string webRootPath = _webHostEnvironment.WebRootPath;
                if (string.IsNullOrEmpty(webRootPath))
                {
                    throw new InvalidOperationException("Web root path is not set.");
                }
                string upload = Path.Combine(webRootPath, "img");

                if (!Directory.Exists(upload))
                {
                    Directory.CreateDirectory(upload);
                }

                foreach (var imgFile in model.ImageUrls)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extensions = Path.GetExtension(imgFile.FileName);

                    using (var filestream = new FileStream(Path.Combine(upload, fileName + extensions), FileMode.Create))
                    {
                        imgFile.CopyTo(filestream);
                    }

                    var img = new ProductImageEntity
                    {
                        ImagePath = fileName + extensions,
                        ProductId = product.Id,
                        
                    };

                    imgList.Add(img);
                }
                product.productImages = imgList;
                _context.ProductImages.AddRange(imgList);
                await _context.SaveChangesAsync();

            }
        }




       



        public async Task Delete(int id)
        {
           var currentPost = await Get(id);

            if (currentPost != null) 
            {
                return;
            }
            ////
        }

        public async Task<CreateProductDto> Get(int id)
        {
            if (id < 0) return null; // exception handling

            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) return null; // exception handling

            return _mapper.Map<CreateProductDto>(product);
        }

        public List<object> GettAllGenders()
        {
            var genders = Enum.GetValues(typeof(Gender))
                             .Cast<Gender>()
                             .Select(s => new
                             {
                                 label = s.ToString(),
                                 value = (int)s
                             })
                             .ToList<object>();

            return genders;
        }

        public async Task<List<object>> GettAllGendersAsync()
        {
            return await Task.FromResult(GettAllGenders());
        }

     
        public List<object> GettAllSizes()
        {
            var sizeOptions = Enum.GetValues(typeof(Size))
                              .Cast<Size>()
                              .Select(s => new
                              {
                                  label = s.ToString(),
                                  value = (int)s
                              })
                              .ToList<object>();

            return sizeOptions;
        }

        public async Task<List<object>> GettAllSizesAsync()
        {
            return await Task.FromResult(GettAllSizes());
        }

       
    }
}
