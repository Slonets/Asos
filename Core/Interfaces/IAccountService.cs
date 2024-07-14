using Core.DTO.Authentication;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto model, int idUser);
        Task<UserEntity> GetUserById(int id);
        Task<IdentityResult> BlockUser(int userId);
        Task<IdentityResult> UnblockUser(int userId);
        Task<List<UserViewDto>> GetAllUsers();
    }
}
