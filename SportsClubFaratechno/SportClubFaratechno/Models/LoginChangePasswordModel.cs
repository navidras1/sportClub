using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class LoginChangePasswordModel : LoginModel
    {
        [Required(ErrorMessage = "لطفا رمز عبور جدید را وارد کنید")]
        public string NewPassword { set; get; }
    }
}
