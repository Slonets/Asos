using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Location
{
    public class TownEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameTown { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public CountryEntity Country { get; set; }
    }
}
