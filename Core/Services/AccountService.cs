using AutoMapper;
using Core.Constants;
using Core.DTO.Authentication;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
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

        public async Task<LoginResultDto> Login(LoginDto model)
        {        

            var user = await _userManager.FindByEmailAsync(model.Email);

            LoginResultDto loginResultDto = new LoginResultDto();

            if (user == null)
            {
                loginResultDto.IsSuccess = false;
                loginResultDto.Error = "Incorect data!";
                return loginResultDto;
            }
            var isAuth = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isAuth)
            {
                loginResultDto.IsSuccess = false;
                loginResultDto.Error = "Incorect data!";
                return loginResultDto;
            }

            if(user.LockoutEnabled==true) 
            {
                loginResultDto.IsSuccess = false;
                loginResultDto.Error = $"User {user.FirstName} {user.LastName} locked to {user.LockoutEnd.Value} years";
                return loginResultDto;
            }

            var token = await _jwtTokenService.CreateToken(user);
            loginResultDto.Token = token;
            loginResultDto.IsSuccess=true;

            return loginResultDto;
        }

        public async Task<RegisterResultDto> Registration(RegisterDto dto)
        {
            RegisterResultDto registerResultDto = new RegisterResultDto();

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
                    registerResultDto.IsSuccess = false;
                    // Логування помилок створення користувача
                    registerResultDto.Error = string.Join($"Не вдалося створити користувача", ",", resultCreated.Errors.Select(e => e.Description));
                    return registerResultDto;                  
                }                

                if (resultCreated.Succeeded)
                {
                    try
                    {
                        _emailService.SuccessfulLogin(dto.FirstName + " " + dto.LastName, dto.Email);
                    }
                    catch (Exception ex)
                    {
                        registerResultDto.IsSuccess = false;
                        registerResultDto.Error = $"Лист на пошту відправити не вдалося";
                        return registerResultDto;
                    }
                }
            }
            else
            {
                registerResultDto.IsSuccess = false;
                registerResultDto.Error = $"Така пошта уже зареєстрована";
                return registerResultDto;                
            }

            // Асинхронне додавання створеного користувача до певної ролі
            var resultRole = await _userManager.AddToRoleAsync(user, Roles.User);

            // Перевірка результату додавання до ролі
            if (!resultRole.Succeeded)
            {
                registerResultDto.IsSuccess = false;
                registerResultDto.Error = string.Join($"Не вдалося додати роль користувачу:", ", ", resultRole.Errors.Select(e => e.Description));
                return registerResultDto;               
            }
            else
            {
                registerResultDto.IsSuccess = true;
                return registerResultDto;
            }
        }

        public async Task<UserEntity> GetUserById(int id)
        {         

            var user = await _userEntity.GetByIDAsync(id);
            
            return user;       
                               
        }

        // Асинхронний метод для зміни даних користувача
        public async Task EditUserAsync(EditUserDto editUserDto)
        {
            var user = await _userEntity.GetByIDAsync(editUserDto.Id);            

            // Синхронні операції зміни даних
            user.FirstName = editUserDto.FirstName;
            user.LastName = editUserDto.LastName;
            user.PhoneNumber = editUserDto.PhoneNumber;
            user.Email = editUserDto.Email;           

            if (editUserDto.Image != null)
            {
                user.Image = editUserDto.Image;
            }

            await _userEntity.UpdateAsync(user);
            await _userEntity.SaveAsync();
        }


        // Асинхронний метод для зміни пароля користувача
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto model, int idUser)
        {
            var user = _userEntity.GetByIDAsync(idUser).Result;            

            var result = await _userManager.ChangePasswordAsync(user, model.currentPassword, model.newPassword);
            
            return result;
        }

        public async Task<IdentityResult> BlockUser(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());//.GetByIDAsync(userId);

            
           var result = await _userManager.SetLockoutEnabledAsync(user, true);
            
            if(result.Succeeded)
            {
                result = await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(100));
            } 

            return result;            
        }

        public async Task<IdentityResult> UnblockUser(int userId)
        {
            RegisterResultDto registerResultDto = new RegisterResultDto();

            var user = await _userManager.FindByIdAsync(userId.ToString());           

            var result = await _userManager.SetLockoutEnabledAsync(user, false);
            if (result.Succeeded)
            {
                result = await _userManager.SetLockoutEndDateAsync(user, DateTime.Now);
            }

            return result;
        }

        public async Task<List<UserViewDto>> GetAllUsers()
        {
            var users = await _userEntity.GetIQueryable()
                .Include(x=>x.UserRoles).ThenInclude(ur=>ur.Role)                
                .ToListAsync();


            return _mapper.Map<List<UserViewDto>>(users);
        }

    }
}
