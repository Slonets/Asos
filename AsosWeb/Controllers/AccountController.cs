using AutoMapper;
using Core.DTO.Authentication;
using Core.Helpers;
using Core.Interfaces;
using Core.Services;
using Core.Validator;
using FluentValidation;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Core.Exceptions;
using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;
using Core.Constants;
using System.Diagnostics.Metrics;
using Infrastructure.Data;


namespace AsosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;        
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        UserManager<UserEntity> _userManager;
        private readonly IRepository<UserEntity> _userEntity;
        private readonly AsosDbContext _context;

        public AccountController(AsosDbContext context ,IRepository<UserEntity> userEntity, IAccountService accountService, IMapper mapper, IJwtTokenService jwtTokenService, UserManager<UserEntity> userManager)
        {
            _accountService = accountService;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
            _userManager=userManager;
            _userEntity = userEntity;
            _context=context;            
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {

            var validator = new LoginValidator();

            var validationResult = validator.Validate(model);

            if (validationResult.IsValid) 
            {
                var result = await _accountService.Login(model);

                if (result.IsSuccess)
                {

                    if (result.baskets != null)
                    {
                        return Ok(new { token = result.Token, array = result.baskets });
                    }
                    else
                    {
                        return Ok(new { token = result.Token });
                    }
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var validator = new RegisterValidator();

            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                var result = await _accountService.Registration(model);

                if (result.IsSuccess)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(result);
                }               
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }

        [HttpPost("GoogleSignIn")]
        public async Task<IActionResult> GoogleSignIn([FromBody] GoogleSignInDto model)
        {           

                var result = await _accountService.GoogleSignInAsync(model);

                if (result.IsSuccess)
                {                    

                       if(result.baskets!=null)
                       {
                          return Ok(new { token = result.Token, baskets= result.baskets});
                       }
                       else
                       {
                             return Ok(new { token = result.Token });
                       }

                }
                else
                {
                    return BadRequest(result);
                }                
        }

        [HttpPut("edit-user")]
        public async Task<IActionResult> EditUser([FromForm] EditUserDto editUserDto)
        {
            await _accountService.EditUserAsync(editUserDto);

            string userId = User.Claims.ToList()[0].Value.ToString();           

            var user = _context.Users
                .Include(x => x.Address)                
                .Include(x => x.Address.Town)
                .FirstOrDefault(x => x.Id == int.Parse(userId));

            var roles = await _userManager.GetRolesAsync(user);

            var userTokenInfo = new UserTokenInfoDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthday = user.Birthday?.ToString("dd-MM-yyyy"),
                Image = user.Image,
                PhoneNumber = user.PhoneNumber,
                Country = user.Address?.Town.CountryId,
                Town = user.Address?.Town.NameTown,
                Address = user.Address?.Street,
                PostCode = user.PostCode,
                Roles = roles.ToList(),
            };

            var token = await _jwtTokenService.CreateToken(userTokenInfo);

            return Ok(new {token});            
        }

        [HttpPut("edit-adrress")]
        public async Task<IActionResult> EditAdrressUser([FromForm] EditAdrressUserDto editDto)
        {
            await _accountService.EditAdrressUserAsync(editDto);

            string userId = User.Claims.ToList()[0].Value.ToString();

            var user = _context.Users
              .Include(x => x.Address)
              .Include(x => x.Address.Town)
              .FirstOrDefault(x => x.Id == int.Parse(userId));

            var roles = await _userManager.GetRolesAsync(user);

            var userTokenInfo = new UserTokenInfoDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Birthday = user.Birthday?.ToString("dd-MM-yyyy"),
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber,
                    Country = user.Address?.Town.CountryId,
                    Town = user.Address.Town.NameTown,
                    Address = user.Address?.Street,
                    PostCode = user.PostCode,
                    Roles = roles.ToList(),
                };

                var token = await _jwtTokenService.CreateToken(userTokenInfo);

                return Ok(new { token });
                        
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordDto model)
        {
            string number = User.Claims.ToList()[0].Value.ToString();

            int idUser = int.Parse(number);

            var result = _accountService.ChangePasswordAsync(model, idUser);

            if (result.Result.Succeeded)
            {
                return Ok(new { message = "Пароль успішно змінено" });
            }
            else
            {
                return BadRequest(new { message = "Змінити пароль не вдалося", result });
            }

        }

       [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            // Отримання користувачів із пагінацією через сервіс
            var result = await _accountService.GetAllUsers(pageNumber, pageSize);

            // Повернення результату з даними та інформацією про пагінацію
            return Ok(result);
        }

        [HttpPost("BlockUser")]
        public async Task<IActionResult> BlockUser([FromBody] BlockUserDto model)
        {
            return Ok(await _accountService.BlockUser(model.UserId));
        }

        [Authorize]
        [HttpGet("UserById")]
        public async Task<IActionResult> GetUser()
        {
            string id = User.Claims.ToList()[0].Value.ToString();

            var user = await _accountService.GetUser(id);            

            return Ok(user);
        }

        [HttpPost("UnBlockUser")]
        public async Task<IActionResult> UnBlockUser([FromBody] BlockUserDto model)
        {
            return Ok(await _accountService.UnblockUser(model.UserId));
        }

    }
}
