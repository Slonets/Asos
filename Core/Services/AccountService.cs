using AutoMapper;
using Core.Constants;
using Core.DTO.Authentication;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
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
        private readonly IRepository<UserEntity> _userEntity;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ISmtpEmailService _emailService;
        private readonly AsosDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IFotoAvatar _fotoAvatar;

        public AccountService(UserManager<UserEntity> userManager,
            IMapper mapper,
            IJwtTokenService jwtTokenService,
            ISmtpEmailService emailService,
            AsosDbContext context,
            IConfiguration configuration,
            IRepository<UserEntity> userEntity,
            IFotoAvatar fotoAvatar
            )
        {

            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
            _emailService = emailService;
            _context = context;
            _configuration = configuration;
            _userEntity = userEntity;
            _fotoAvatar = fotoAvatar;
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
        public bool IsEmailRegistered(string email)
        {
            return _context.Users.Any(user => user.Email == email);
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
            // Маппінг об'єкта dto на об'єкт UserEntity за допомогою _mapper
            UserEntity user = _mapper.Map<UserEntity>(dto);

            // Перевірка, чи такий email вже зареєстрований
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);


            if (existingUser == null)
            {
                // Асинхронне створення нового користувача з паролем
                var resultCreated = await _userManager.CreateAsync(user, dto.Password);


                // Перевірка результату створення користувача
                if (!resultCreated.Succeeded)
                {
                    // Логування помилок створення користувача
                    var errors = string.Join(", ", resultCreated.Errors.Select(e => e.Description));
                    throw new CustomHttpException($"Не вдалося створити користувача: {errors}", HttpStatusCode.BadRequest);
                }

                if (resultCreated.Succeeded)
                {
                    try
                    {
                        _emailService.SuccessfulLogin(dto.FirstName + " " + dto.LastName, dto.Email);
                    }
                    catch (Exception ex)
                    {
                        throw new CustomHttpException("Лист на пошту відправити не вдалося", HttpStatusCode.BadRequest);
                    }
                }
            }
            else
            {
                throw new CustomHttpException("Така пошта уже зареєстрована", HttpStatusCode.BadRequest);
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


        }

        public async Task<UserEntity> GetUserById(int id)
        {
            var user = await _userEntity.GetByIDAsync(id);

            if (user == null)
            {
                throw new CustomHttpException($"Користувача не знайдено", HttpStatusCode.NotFound);
            }
            else
            {
                return user;
            }
        }

        // Асинхронний метод для зміни даних користувача
        public async Task EditUserAsync(EditUserDto editUserDto)
        {
            var user = await _userEntity.GetByIDAsync(editUserDto.Id);

            if (user == null)
            {
                throw new CustomHttpException($"Користувача з Id = {editUserDto.Id} не знайдено", HttpStatusCode.NotFound);
            }

            // Синхронні операції зміни даних
            user.FirstName = editUserDto.FirstName;
            user.LastName = editUserDto.LastName;
            user.PhoneNumber = editUserDto.PhoneNumber;
            user.Email = editUserDto.Email;

           
                await _userEntity.UpdateAsync(user);
                await _userEntity.SaveAsync();
            

            //if (editUserDto.Image != null)
            //{



            //    var resultUpdate = await _userManager.UpdateAsync(user);
            //    await _userEntity.SaveAsync();

            //    if (!resultUpdate.Succeeded)

            //        try
            //        {
            //            var errors = string.Join(", ", resultUpdate.Errors.Select(e => e.Description));
            //            throw new CustomHttpException($"Не вдалося оновити користувача: {errors}", HttpStatusCode.BadRequest);

            //        }
            //        catch (Exception ex)
            //        {
            //            throw new CustomHttpException($"Фото не оновилося: {ex.Message}", HttpStatusCode.NotFound);
            //        }
            //}
        }


        // Асинхронний метод для зміни пароля користувача
        //public async Task ChangePasswordAsync(RegisterDto user, string currentPassword, string newPassword, string confirmNewPassword)
        //{
        //    if (user.Password != currentPassword)
        //    {
        //        throw new CustomHttpException($"Паролі не співпадають", HttpStatusCode.NotFound);
        //    }

        //    if (newPassword != confirmNewPassword)
        //    {
        //        throw new CustomHttpException($"Підтвердження і новий пароль не співпадають", HttpStatusCode.NotFound);
        //    }

        //    // Синхронні операції зміни пароля
        //    user.Password = newPassword;
        //    user.ConfirmPassword = confirmNewPassword;

        //    await _userEntity.UpdateAsync(_mapper.Map<UserEntity>(user));
        //}


    }
}
