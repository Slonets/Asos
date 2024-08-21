using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Location
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string? Street { get; set; }

        [ForeignKey("TownEntity")]
        public int TownId { get; set; }
        public TownEntity Town { get; set; }
    }
}
