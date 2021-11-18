using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class RegisterAccessModel
    {
        [Required(ErrorMessage = "آدرس وب ای پی آی الزامی است.")]
        public string WebApiAddress { get; set; }

        [Required(ErrorMessage = "نام دسترسی الزامی است.")]
        public string Name { get; set; }
    }
}
