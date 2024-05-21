using Infrastructure.Entities;

namespace Core.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateToken(UserEntity user);
    }
}
