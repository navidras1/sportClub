using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class ClubSalon
    {
        public  long Id { get; set; }
        public long ClubId { get; set; }
        public long SalonId { get; set; }
    }
}
