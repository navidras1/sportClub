using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AccessRoleResultModel
    {
        public Access Access { get; set; }
        public List<AppRole> AppRoles { get; set; }
    }
}
