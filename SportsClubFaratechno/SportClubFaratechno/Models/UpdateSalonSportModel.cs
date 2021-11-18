using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class UpdateSalonSportModel
    {
        [Required(ErrorMessage = "لطفا آی دی را وارد کنید")]
        public long Id { get; set; }
        
        [Required(ErrorMessage = "لطفا آی دی سالن را وارد کنید")]
        public long? SalonTypeId { get; set; }
        
        [Required(ErrorMessage = "لطفا آی دی رشته را وارد کنید")]
        public long? SportTypeId { get; set; }

        public string Desctiption { get; set; }
        public bool? SalonCabinetPrioraty { get; set; }
    }
}
