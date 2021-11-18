using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AssignCabinetToUserModel
    {
        public long UserId { get; set; }
        public long CabinetId { get; set; }
    }
}
