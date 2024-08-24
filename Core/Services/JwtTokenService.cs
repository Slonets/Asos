using Core.DTO.Authentication;
using Core.Interfaces;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<UserEntity> _userManager;

        public JwtTokenService(IConfiguration config, UserManager<UserEntity> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        public async Task<string> CreateToken(UserTokenInfoDto user)
        {         

            // Отримуємо ролі користувача
            var roles = user.Roles;

            // Формуємо список клеймів
            List<Claim> claims = new()
            {
              new Claim("id", user.Id.ToString()),
              new Claim("firstName", user.FirstName),
              new Claim("lastName", user.LastName),
              new Claim("email", user.Email),
              new Claim("phoneNumber", user.PhoneNumber ?? string.Empty),
              new Claim("image", user.Image ?? string.Empty),
              new Claim("birthday", user.Birthday ?? string.Empty),
              new Claim("address", user.Address ?? string.Empty), // Адреса як рядок
              new Claim("town", user.Town ?? string.Empty), // Назва міста як рядок
              new Claim("country", user.Country.ToString()), // ID країни як число (перетворене на рядок)
              new Claim("postCode", user.PostCode.ToString()), // Поштовий код як число (перетворене на рядок)
             };

            // Додаємо ролі як окремі клейми
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<String>("JwtSecretKey")));
            var signinCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signinCredentials,
                expires: DateTime.Now.AddDays(10),
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
