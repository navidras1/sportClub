using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AddSalonEqueepmetModel
    {
        [Required(ErrorMessage = "لطفا آی دی سالن را وارد کنید")]
        public long? SalonId { get; set; }
        [Required(ErrorMessage = "لطفا نام دستگاه را وارد کنید")]
        public string Equipment { get; set; }
        [Required(ErrorMessage = "لطفا تعداد دستگاه را وارد کنید")]
        public int? Quantity { get; set; }

        public bool? IsFreeToUse { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
    }
}
