using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AssignSportToSalonModel
    {
        [Required(ErrorMessage = "لطفا آی دی سالن را وارد کنید")]
        public long? SalonTypeId { get; set; }

        [Required(ErrorMessage = "لطفا آی دی ورزش را وارد کنید")]
        public long? SportTypeId { get; set; }

        public string Desctiption { get; set; }



    }
}
