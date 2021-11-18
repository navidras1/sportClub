using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class UpdateDetailModel
    {
        [Required(ErrorMessage = "نام فعلی الزامی است")]
        public string OldName { get; set; }
        [Required(ErrorMessage = "نام جدید الزامی است")]
        public string NewName { get; set; }

    }
}
