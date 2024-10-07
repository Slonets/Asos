using AutoMapper;
using Core.DTO.Authentication;
using Core.DTO.Site.Category;
using Core.DTO.Site.Product;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities.Enums;
using Infrastructure.Entities.Location;
using Infrastructure.Entities.Site;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IRepository<ProductEntity> _products;       

        public ProductService(IRepository<ProductEntity> products, IMapper mapper, AsosDbContext asosDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _context = asosDbContext;
            _webHostEnvironment = webHostEnvironment;
            _products=products;
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
                string upload = Path.Combine(webRootPath, "product");

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
                product.ProductImages = imgList;
                _context.ProductImages.AddRange(imgList);
                await _context.SaveChangesAsync();

            }
        }

        public async Task AddProductImages(int productId, List<IFormFile> images)
        {
            var product = await _context.Products.Include(p => p.ProductImages)
                                                 .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException("Product not found");

            if (images != null && images.Any())
            {
                var imgList = new List<ProductImageEntity>();
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (string.IsNullOrEmpty(webRootPath))
                {
                    throw new InvalidOperationException("Web root path is not set.");
                }

                string upload = Path.Combine(webRootPath, "product");

                if (!Directory.Exists(upload))
                {
                    Directory.CreateDirectory(upload);
                }

                foreach (var imgFile in images)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extensions = Path.GetExtension(imgFile.FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extensions), FileMode.Create))
                    {
                        await imgFile.CopyToAsync(fileStream);
                    }

                    var img = new ProductImageEntity
                    {
                        ImagePath = fileName + extensions,
                        ProductId = productId
                    };

                    imgList.Add(img);
                }

                _context.ProductImages.AddRange(imgList);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false; // Товар не знайдено
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true; // Видалення успішне
        }




        public async Task<CreateProductDto> Get(int id)
        {
            if (id < 0) return null; // exception handling

            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) return null; // exception handling

            return _mapper.Map<CreateProductDto>(product);
        }

        public async Task<GetProductByIdDto> GetById(int id)
        {
            var product = await _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.ProductImages)
            .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

         

            // Перетворюємо дані продукту в DTO (Data Transfer Object)
            var productDto = new GetProductByIdDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Size = product.Size,
                Color = product.Color,
                Gender = product.Gender,
                SizeAndFit = product.SizeAndFit,
                LookAfterMe = product.LookAfterMe,
                AboutMe = product.AboutMe,
                Amount = product.Amount,
                Price = product.Price,
                ImageUrls = product.ProductImages.Select(img => img.ImagePath).ToList()  
            };
            return productDto;
        }

        public async Task<PagedResult<GetAllProductDto>> GetAllProducts(int pageNumber, int pageSize)
        {
            var query = _context.Products;

            // Загальна кількість продуктів
            var totalProducts = await query.CountAsync();

            // Повернення продуктів для конкретної сторінки
            var products = await _context.Products
                .Include(p=> p.ProductImages)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var productDtos = _mapper.Map<List<GetAllProductDto>>(products);

            return new PagedResult<GetAllProductDto>
            {
                Items = productDtos,
                TotalCount = totalProducts,
                PageSize = pageSize,
                CurrentPage = pageNumber,
            };
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

        public async Task Update(UpdateProductDto model)
        {
            int id = model.Id;
            var product = await _context.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            // Оновлення даних продукту
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Size = model.Size;
            product.Color = model.Color;
            product.BrandId = model.BrandId;
            product.CategoryId = model.CategoryId;
            product.Gender = model.Gender;
            product.LookAfterMe = model.LookAfterMe;
            product.AboutMe = model.AboutMe;
            product.SizeAndFit = model.SizeAndFit;
            product.Amount = model.Amount;

            // Видалення зображень
            if (model.ImageUrlsToRemove != null && model.ImageUrlsToRemove.Count > 0)
            {
                foreach (var imagePath in model.ImageUrlsToRemove)
                {
                    // Знайти зображення в базі
                    var imageEntity = product.ProductImages.FirstOrDefault(img => img.ImagePath == imagePath);
                    if (imageEntity != null)
                    {
                        // Видалити файл
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                        // Видалити запис з бази
                        _context.ProductImages.Remove(imageEntity);
                    }
                }
            }

            // Додавання нових зображень
            if (model.ImageUrls != null)
            {
                foreach (var file in model.ImageUrls)
                {
                    var filePath = Path.Combine("wwwroot", "img", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var productImage = new ProductImageEntity
                    {
                        ImagePath = filePath,
                        ProductId = product.Id,
                    };

                    product.ProductImages.Add(productImage); 
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<ViewManClothingDto>> GetManClothingAsync()
        {
            var clothing = await _context.Products.Where(x => x.Gender == Gender.Male)
                                                  .Include(x => x.ProductImages)
                                                  .Include(x => x.Brand)
                                                  .Include(x => x.Category)
                                                  .ToListAsync();             

            return _mapper.Map<List<ViewManClothingDto>>(clothing);
        }
        public async Task<List<ViewManClothingDto>> GetWomanClothingAsync()
        {
            var clothing = await _context.Products.Where(x => x.Gender == Gender.Female)
                                                  .Include(x => x.ProductImages)
                                                  .Include(x => x.Brand)
                                                  .Include(x => x.Category)
                                                  .ToListAsync();             

            return _mapper.Map<List<ViewManClothingDto>>(clothing);
        }

        public async Task<List<ViewManClothingDto>> GetArrayFavorite(int[] array)
        {
            // Отримуємо всі продукти
            var products = await _products.GetIQueryable()
                .Include(x=>x.ProductImages)
                .Include(x=>x.Brand)
                .Include(x=>x.Category)
                .ToListAsync();
           
            var unit = products.ToArray();

            // Ліст для повернення товарів
            List<ProductEntity> returnProduct = new List<ProductEntity>();

            // Для кожного елемента у масиві array перевіряємо наявність у unit
            foreach (var id in array)
            {
                // Знаходимо товар з таким же ID
                var product = unit.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    returnProduct.Add(product);
                }
            }
            
            return _mapper.Map<List<ViewManClothingDto>>(returnProduct);
        }

        public async Task<bool> DeleteImageAsync(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return false; // Шлях до зображення не може бути пустим
            }

            // Знайдемо зображення в базі даних
            var imageEntity = await _context.ProductImages.FirstOrDefaultAsync(img => img.ImagePath == imagePath);

            if (imageEntity == null)
            {
                return false; // Зображення не знайдено
            }

            // Логіка видалення файлу з файлової системи
            var filePath = Path.Combine("wwwroot/images/products", imageEntity.ImagePath); // Вкажіть правильний шлях до вашого зображення

            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Видалення файлу
            }

            // Видалення запису з бази даних
            _context.ProductImages.Remove(imageEntity);
            await _context.SaveChangesAsync();

            return true; // Видалення успішне
        }
    }
}
