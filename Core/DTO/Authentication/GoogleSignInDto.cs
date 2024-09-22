using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Authentication
{
    public class GoogleSignInDto
    {
        public string Credential { get; set; } = null!;
        public List<int> Baskets { get; set; }= new List<int>();
    }
}
