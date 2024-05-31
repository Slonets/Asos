using AutoMapper;
using Core.Constants;
using Core.DTO.Authentication;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Net;
using static Google.Apis.Auth.GoogleJsonWebSignature;


namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ISmtpEmailService _emailService;
        private readonly AsosDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<UserEntity> userManager,
            IMapper mapper,
            IJwtTokenService jwtTokenService,
            ISmtpEmailService emailService,
            AsosDbContext context,
            IConfiguration configuration)
        {

            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
            _emailService = emailService;
            _context = context;
            _configuration = configuration;
        }
    
         public async Task<UserEntity> GoogleSignInAsync(GoogleSignInDto model)
         {
            Payload payload = await GetPayloadAsync(model.Credential);

              UserEntity? user = await _userManager.FindByEmailAsync(payload.Email);

              user ??= await CreateGoogleUserAsync(payload);

           return user;
         }

        private async Task<Payload> GetPayloadAsync(string credential)
        {
            return await ValidateAsync(
                credential,
                new ValidationSettings
                {
                    Audience = [_configuration["Authentication:Google:ClientId"]]
                }
            );
        }
        private async Task<UserEntity> CreateGoogleUserAsync(Payload payload)
        {
            using var httpClient = new HttpClient();

            var user = new UserEntity
            {
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                Email = payload.Email,
                UserName = payload.Email,
                
            };


            try
            {
                await CreateUserAsync(user);
            }
            catch
            {
               
                throw;
            }



            return user;
        }


        private async Task CreateUserAsync(UserEntity user, string? password = null)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                IdentityResult identityResult = await CreateUserInDatabaseAsync(user, password);
                if (!identityResult.Succeeded)
                    throw new IdentityException(identityResult, "User creating error");

                identityResult = await _userManager.AddToRoleAsync(user, Roles.User);
                if (!identityResult.Succeeded)
                    throw new IdentityException(identityResult, "Role assignment error");

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async Task<IdentityResult> CreateUserInDatabaseAsync(UserEntity user, string? password)
        {
            if (password is null)
                return await _userManager.CreateAsync(user);

            return await _userManager.CreateAsync(user, password);
        }







        public async Task<string> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new CustomHttpException($"Невірний логін", HttpStatusCode.NotFound);
            }
            var isAuth = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isAuth)
            {
                throw new CustomHttpException($"Невірний пароль", HttpStatusCode.NotFound);
            }
            var token = await _jwtTokenService.CreateToken(user);

            return token;
        }

        public async Task Registration(RegisterDto dto)
        {
            // Перевірка, чи паролі збігаються
            if (dto.Password != dto.ConfirmPassword)
            {
                throw new CustomHttpException("Паролі не збігаються", HttpStatusCode.BadRequest);
            }

            // Маппінг об'єкта dto на об'єкт UserEntity за допомогою _mapper
            UserEntity user = _mapper.Map<UserEntity>(dto);

            // Асинхронне створення нового користувача з паролем
            var resultCreated = await _userManager.CreateAsync(user, dto.Password);

            // Перевірка результату створення користувача
            if (!resultCreated.Succeeded)
            {
                // Логування помилок створення користувача
                var errors = string.Join(", ", resultCreated.Errors.Select(e => e.Description));
                throw new CustomHttpException($"Не вдалося створити користувача: {errors}", HttpStatusCode.BadRequest);
            }
            
            if(resultCreated.Succeeded)
            {
                try
                {
                    _emailService.SuccessfulLogin(dto.FirstName + " " + dto.LastName, dto.Email);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }

            // Асинхронне додавання створеного користувача до певної ролі
            var resultRole = await _userManager.AddToRoleAsync(user, Roles.User);

            // Перевірка результату додавання до ролі
            if (!resultRole.Succeeded)
            {
                // Логування помилок додавання до ролі
                var errors = string.Join(", ", resultRole.Errors.Select(e => e.Description));
                throw new CustomHttpException($"Не вдалося додати роль користувачу: {errors}", HttpStatusCode.BadRequest);
            }           

            // Перевірка, чи dto містить зображення
            if (dto.Image != null)
            {
                // Визначення шляху до папки для збереження аватарок
                var uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "images", "avatars");

                // Перевірка, чи існує папка
                if (!Directory.Exists(uploadFolderPath))
                {
                    // Створення папки, якщо вона не існує
                    Directory.CreateDirectory(uploadFolderPath);
                }

                // Перевірка, чи поле Image у користувача не порожнє
                if (!string.IsNullOrEmpty(user.Image))
                {
                    // Визначення шляху до старого файлу зображення
                    var delFilePath = Path.Combine(uploadFolderPath, user.Image);

                    // Перевірка, чи існує старий файл зображення
                    if (File.Exists(delFilePath))
                    {
                        // Видалення старого файлу зображення
                        File.Delete(delFilePath);
                    }
                }

                try
                {
                    // Генерація унікального імені файлу
                    string webFileName = Guid.NewGuid().ToString() + ".webp";

                    var filePath = Path.Combine(uploadFolderPath, webFileName); // Визначення шляху до нового файлу зображення

                    // Створення файлового потоку для запису файлу
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        // Асинхронне копіювання зображення до файлового потоку
                        await dto.Image.CopyToAsync(stream);
                    }

                    // Завантаження зображення для обробки
                    using (var image = Image.Load(filePath))
                    {
                        // Зміна розміру зображення
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(150, 150), // Встановлення розмірів зображення
                            Mode = ResizeMode.Max // Встановлення режиму зміни розміру
                        }));

                        image.Save(filePath); // Збереження обробленого зображення
                    }

                    // Збереження імені нового файлу зображення в поле Image користувача
                    user.Image = webFileName;

                    // Асинхронне оновлення даних користувача
                    var resultUpdate = await _userManager.UpdateAsync(user);

                    // Перевірка результату оновлення користувача
                    if (!resultUpdate.Succeeded)
                    {
                        var errors = string.Join(", ", resultUpdate.Errors.Select(e => e.Description));
                        throw new CustomHttpException($"Не вдалося оновити користувача: {errors}", HttpStatusCode.BadRequest);
                    }
                }
                catch (Exception ex)
                {
                    throw new CustomHttpException($"Фото не додалося: {ex.Message}", HttpStatusCode.NotFound);
                }
            }
        }

    }
}
