using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class UpdateSalonModel
    {
        public long SalonId { get; set; }
        public string SalonName { get; set; }
        public string SalonDescription { get; set; }
        public long ClubId { get; set; }
    }
}
