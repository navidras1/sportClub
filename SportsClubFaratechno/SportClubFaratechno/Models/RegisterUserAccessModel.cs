using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class RegisterUserAccessModel
    {
        [Required(ErrorMessage = "لطفا آی دی دسترسی را وارد کنید")]
        public long? AccessId { get; set; }
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا وجود دسترسی را وارد کنید")]
        public bool? HasAccess { get; set; }
    }
}
