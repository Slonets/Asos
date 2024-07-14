using Core.DTO.Site.Brand;
using Core.DTO.Site.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GettAll();
    }
}
