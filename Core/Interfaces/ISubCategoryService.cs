using Core.DTO.Site.Category;
using Core.DTO.Site.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubCategoryService
    {
        Task<List<SubCategoryDto>> GettAll();
    }
}
