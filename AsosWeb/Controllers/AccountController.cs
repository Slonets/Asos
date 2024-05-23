using AutoMapper;
using Core.DTO.Authentication;
using Core.Helpers;
using Core.Interfaces;
using Core.Services;
using Core.Validator;
using FluentValidation;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AsosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;        
        private readonly IMapper _mapper;       

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;            
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

        [AllowAnonymous]
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
    }
}
