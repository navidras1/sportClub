using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class EditUserAccessModel
    {
        [Required(ErrorMessage = "لطفا آی دی را وارد کنید")]
        public long? Id { get; set; }
        [Required(ErrorMessage = "لطفا وجود دسترسی را وارد کنید")]
        public bool? HasAccess { get; set; }
    }
}
