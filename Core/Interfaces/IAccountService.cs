using Core.DTO.Authentication;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        Task<string> Login(LoginDto loginDto);
        Task Registration(RegisterDto dto);       
        Task<UserEntity> GoogleSignInAsync(GoogleSignInDto loginDto);
        Task EditUserAsync(EditUserDto editUserDto);
        //Task ChangePasswordAsync(RegisterDto user, string currentPassword, string newPassword, string confirmNewPassword);
        Task<UserEntity> GetUserById(int id);        
    }
}
