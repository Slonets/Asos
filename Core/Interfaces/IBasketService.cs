using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBasketService
    {
        Task pushBasketById(int id, int user);
        Task pushBasketArray(int userId, int[] productIds);
    }
}
