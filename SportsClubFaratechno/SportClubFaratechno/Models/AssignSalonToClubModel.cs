using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AssignSalonToClubModel
    {
        [Required(ErrorMessage = "لطفا آی دی باشگاه را وارد کنید")]
        public long ClubId { get; set; }
        [Required(ErrorMessage = "لطفا آی دی سالن را وارد کنید")]
        public long SalonId { get; set; }
    }
}
