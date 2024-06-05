﻿using AutoMapper;
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


namespace AsosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;        
        private readonly IMapper _mapper;    
        private readonly IJwtTokenService _jwtTokenService;
        UserManager<UserEntity> userManager;

        public AccountController(IAccountService accountService, IMapper mapper, IJwtTokenService jwtTokenService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
            
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var validator = new LoginValidator();

            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                var token = await _accountService.Login(model);

                return Ok(new { token });
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
                await _accountService.Registration(model);
                return Ok();
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }         
        }

        [HttpPost("GoogleSignIn")]
        public async Task<IActionResult> GoogleSignIn([FromForm] GoogleSignInDto model)
        {
            try
            {
                UserEntity user = await _accountService.GoogleSignInAsync(model);

                return Ok(new JwtTokenResponseDto
                {
                    Token = await _jwtTokenService.CreateToken(user)
                });
            }
            catch (InvalidJwtException e)
            {
                return Unauthorized(e.Message);
            }
            catch (IdentityException e)
            {
                return StatusCode(500, e.IdentityResult.Errors);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserData([FromBody] RegisterDto user, [FromQuery] string newFirstName, [FromQuery] string newLastName, [FromQuery] string newPhoneNumber, [FromQuery] string newEmail)
        {
            await _accountService.UpdateUserDataAsync(user, newFirstName, newLastName, newPhoneNumber, newEmail);
            return Ok(new { message = "User data updated successfully" });
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] RegisterDto user, [FromQuery] string currentPassword, [FromQuery] string newPassword, [FromQuery] string confirmNewPassword)
        {
            var result = await _accountService.ChangePasswordAsync(user, currentPassword, newPassword, confirmNewPassword);
            
            if (!result)
            {
                return BadRequest(new { message = "Змінити пароль не вдалося" });
            }

            return Ok(new { message = "Пароль успішно змінено" });
        }
    }
}
