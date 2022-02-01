using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class Club
    {
        public long Id { get; set; }
        public long ClubId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
