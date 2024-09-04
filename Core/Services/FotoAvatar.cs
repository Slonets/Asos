using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class FotoAvatar : IFotoAvatar
    {
        private const string imageFolder = "avatars";
        private readonly IWebHostEnvironment _environment;

        public FotoAvatar(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> SaveFotoProduct(string url)
        {
            try
            {
                // Отримуємо шлях до wwwroot
                string root = _environment.WebRootPath;

                // Вказуємо папку для зберігання зображень
                string imageFolder = "product";
                string folderPath = Path.Combine(root, imageFolder);

                // Перевіряємо, чи існує папка, якщо ні - створюємо
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Генеруємо нову назву для файлу
                string newNameFile = Guid.NewGuid().ToString();
                string fileName = $"{newNameFile}.webp";

                // Повний шлях до файлу
                string imageFullPath = Path.Combine(folderPath, fileName);

                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        using (var stream = response.Content.ReadAsStreamAsync().Result)
                        {
                            using (var image = Image.Load(stream))
                            {
                                // Збереження зображення у форматі WebP
                                image.Save(imageFullPath, new WebpEncoder());
                            }
                        }
                        return fileName;
                    }
                    else
                    {
                        Console.WriteLine($"Не вдалося завантажити зображення за URL: {url}");
                        return "Download failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу: {ex.Message}");
                return ex.Message;
            }
        }

        public async Task<string> SaveFotoAvatar(IFormFile? file)
        {
            try
            {
                // Отримуємо шлях до wwwroot
                string root = _environment.WebRootPath;

                // Вказуємо папку для зберігання зображень
                string imageFolder = "avatars";
                string folderPath = Path.Combine(root, imageFolder);

                // Перевіряємо, чи існує папка, якщо ні - створюємо
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Генеруємо нову назву для файлу
                string newNameFile = Guid.NewGuid().ToString();
                string fileName = $"{newNameFile}.webp";

                // Повний шлях до файлу
                string imageFullPath = Path.Combine(folderPath, fileName);
                {
                    using (var image = Image.Load(file.OpenReadStream()))
                    {
                        //image.Mutate(x => x.Resize(new ResizeOptions
                        //{
                        //    Size = new Size(size, size),
                        //    Mode = ResizeMode.Max
                        //}));
                        await image.SaveAsync(imageFullPath, new WebpEncoder());
                    }
                }
                return fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу {ex.Message}");
                return ex.Message;
            }
        }

        public async Task<string> UpdateFoto(IFormFile? file, string existingFileName)
        {
            try
            {
                // Визначаємо кореневий шлях
                string root = _environment.WebRootPath;

                // Якщо існує старий файл, видаляємо його
                if (!string.IsNullOrEmpty(existingFileName))
                {
                    string existingFilePath = Path.Combine(root, imageFolder, existingFileName);
                    if (System.IO.File.Exists(existingFilePath))
                    {
                        System.IO.File.Delete(existingFilePath);
                    }
                }

                // Генеруємо нове ім'я файлу
                string newNameFile = Guid.NewGuid().ToString();
                string fileName = $"{newNameFile}.webp";
                string imagePath = Path.Combine(imageFolder, fileName);
                string imageFullPath = Path.Combine(root, imagePath);

                // Зберігаємо нове зображення
                using (var image = Image.Load(file.OpenReadStream()))
                {
                    await image.SaveAsync(imageFullPath, new WebpEncoder());
                }

                return fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу {ex.Message}");
                return ex.Message;
            }
        }
    }
}
