using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class EnterSessionUserTrafficModel
    {

        [Required(ErrorMessage = "لطفا ای دی کاربر دوره را وارد کنید.")]
        public long? SessionUserId { get; set; }
        public DateTime? EntranceDatetime { get; set; }
        public string EntranceDatetimeShamsi { get; set; }
       
        public string Description { get; set; }
    }
}
