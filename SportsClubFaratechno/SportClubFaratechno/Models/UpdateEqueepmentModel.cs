using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class UpdateEqueepmentModel
    {
        [Required(ErrorMessage = "لطفا آی دی دستگاه را وارد کنید.")]
        public long? Id { get; set; }
        public long? SalonId { get; set; }
        public string Equipment { get; set; }
        public int? Quantity { get; set; }
        public bool? IsFreeToUse { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
    }
}
