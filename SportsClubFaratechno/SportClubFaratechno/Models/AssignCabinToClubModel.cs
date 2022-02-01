using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AssignCabinToClubModel
    {

        [Required(ErrorMessage = "لطفا شناسه باشگاه را وارد کنید")]
        public long ClubId { get; set; }
        [Required(ErrorMessage = "لطفا شناسه کمد را وارد کنید.")]
        public long CabinetId { get; set; }
    }
}
