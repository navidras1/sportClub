using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class AppUser: IdentityUser<long>
    {
        public double Credit { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string MobileNo { get; set; }
        public string LandlineNo { get; set; }

    }
}
