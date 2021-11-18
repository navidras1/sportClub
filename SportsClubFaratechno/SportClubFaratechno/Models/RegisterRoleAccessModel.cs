using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class RegisterRoleAccessModel
    {
        [Required(ErrorMessage = "لطفا آی دی دسترسی را وارد کنید")]
        public long? AccessId { get; set; }

        [Required(ErrorMessage = "لطفا آی دی نقش را وارد کنید")]
        public long? RoleId { get; set; }
    }
}
