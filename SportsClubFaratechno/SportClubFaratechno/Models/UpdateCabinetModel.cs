using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class UpdateCabinetModel
    {
        [Required(ErrorMessage = "لطفا نوع کمد را وارد کنید.")]
        public long? CabinetType { get; set; }
        [Required(ErrorMessage = "لطفا نام کمد را وارد کنید.")]
        public string CabinetName { get; set; }
        
        public string Description { get; set; }
    }
}
