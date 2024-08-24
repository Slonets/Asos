using Core.DTO.Authentication;
using Infrastructure.Entities;

namespace Core.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateToken(UserTokenInfoDto user);
    }
}
