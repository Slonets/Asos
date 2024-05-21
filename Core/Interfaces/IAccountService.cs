using Core.DTO.Authentication;
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
    }
}
