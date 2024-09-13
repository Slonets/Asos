using Core.DTO.Authentication;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResultDto> Login(LoginDto loginDto);
        Task<RegisterResultDto> Registration(RegisterDto dto);
        Task<LoginResultDto> GoogleSignInAsync(GoogleSignInDto loginDto);
        Task EditUserAsync(EditUserDto editUserDto); 
        Task EditAdrressUserAsync(EditAdrressUserDto editAdrressDto);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto model, int idUser);
        Task<UserEntity> GetUser(string id);
        Task<IdentityResult> BlockUser(int userId);
        Task<IdentityResult> UnblockUser(int userId);
        //Task<List<UserViewDto>> GetAllUsers();
        Task<PagedResult<UserViewDto>> GetAllUsers(int pageNumber, int pageSize);
    }
}
