using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Location
{
   public class CountryEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameCountry { get; set; }
        public virtual ICollection<TownEntity> Towns { get; set; }
    }
}
