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
        Task<string> SaveFotoAvatar(IFormFile? file);
        Task<string> UpdateFoto(IFormFile? file, string existingFileName);
        Task<string> SaveFotoProduct(string url);
    }
}
