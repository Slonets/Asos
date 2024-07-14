using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFotoAvatar
    {
        Task<string> SaveFoto(IFormFile? file);
        Task<string> UpdateFoto(IFormFile? file, string existingFileName);
    }
}
