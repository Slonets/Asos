using Core.DTO.Authentication;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResultDto> Login(LoginDto loginDto);
        Task<RegisterResultDto> Registration(RegisterDto dto);
        Task<UserEntity> GoogleSignInAsync(GoogleSignInDto loginDto);
        Task EditUserAsync(EditUserDto editUserDto);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto model, int idUser);
        Task<UserEntity> GetUserById(int id);
        Task<IdentityResult> BlockUser(int userId);
        Task<IdentityResult> UnblockUser(int userId);
        Task<List<UserViewDto>> GetAllUsers();
    }
}
