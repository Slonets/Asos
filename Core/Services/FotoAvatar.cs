using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp;

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

        public async Task<string> SaveFoto(IFormFile? file)
        {
            try
            {

                string root = _environment.WebRootPath;
                string newNameFile = Guid.NewGuid().ToString();
                string fileName = $"{newNameFile}.webp";

                string fullFileName = $"{newNameFile}.webp";
                string imagePath = Path.Combine(imageFolder, fullFileName);
                string imageFullPath = Path.Combine(root, imagePath);
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
