using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class IdentityRoleModel
    {
        [Required(ErrorMessage = "لطفا نقش را وارد کنید")]
        public string RoleName { get; set; }
    }
}
