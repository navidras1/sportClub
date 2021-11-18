using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class RoleUserModel
    {
        [Required(ErrorMessage = "لطفا نقش را وارد کنید")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }
    }
}
