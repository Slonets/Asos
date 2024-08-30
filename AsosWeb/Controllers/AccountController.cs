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
using Microsoft.EntityFrameworkCore;


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

        public AccountController(IAccountService accountService, IMapper mapper, IJwtTokenService jwtTokenService, UserManager<UserEntity> userManager)
        {
            _accountService = accountService;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
            _userManager=userManager;
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
                
                    return Ok(new { token = result.Token });
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

        [HttpPut("edit-user")]
        public async Task<IActionResult> EditUser([FromForm] EditUserDto editUserDto)
        {

            await _accountService.EditUserAsync(editUserDto);

            string id = User.Claims.ToList()[0].Value.ToString();

            var user = _userManager.FindByIdAsync(id).Result;

            var token = await _jwtTokenService.CreateToken(user);

            return Ok(new {token});            
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
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _accountService.GetAllUsers());
        }

        [HttpPost("BlockUser")]
        public async Task<IActionResult> BlockUser([FromBody] BlockUserDto model)
        {
            return Ok(await _accountService.BlockUser(model.UserId));
        }


        [HttpPost("UnBlockUser")]
        public async Task<IActionResult> UnBlockUser(int userId)
        {
            return Ok(await _accountService.UnblockUser(userId));
        }
    }
}
