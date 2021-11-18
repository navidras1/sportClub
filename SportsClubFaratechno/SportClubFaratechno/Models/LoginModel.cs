using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string Username { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
