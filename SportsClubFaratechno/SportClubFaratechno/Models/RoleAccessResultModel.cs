using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class RoleAccessResultModel
    {
        public AppRole AppRole { get; set; }
        public List<Access> Accesses { get; set; }
    }
}
