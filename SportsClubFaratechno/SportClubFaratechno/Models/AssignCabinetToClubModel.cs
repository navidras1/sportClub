using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AssignCabinetToSalonModel
    {
        public List<long> SalonIds { get; set; }
        public long CabinetId { get; set; }
    }
}
