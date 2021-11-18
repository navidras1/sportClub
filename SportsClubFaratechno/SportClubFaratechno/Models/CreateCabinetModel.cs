using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class CreateCabinetModel
    {
        [Required(ErrorMessage = "لطفا نام کمد یا کمد ها را وارد کنید.")]
        public List<string> CabinetNames { get; set; }
        [Required(ErrorMessage = "لطفا ای دی نوع کمد را وارد کنید.")]
        public long? CabinetType { get; set; }

    }
}
