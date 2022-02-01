using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class RegisterClubModel
    {
        [Required(ErrorMessage = "لطفا آی دی باشگاه را وارد کنید")]
        public long ClubId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
