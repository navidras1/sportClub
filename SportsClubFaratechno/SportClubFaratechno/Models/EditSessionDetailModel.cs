using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class EditSessionDetailModel
    {
        [Required(ErrorMessage = "لطفا آی دی را وارد کنید")]
        public long Id { get; set; }
        [Required(ErrorMessage = "لطفا آی دی دوره را وارد کنید")]
        public long? SessionId { get; set; }
        
        public string SessionDateShamsi { get; set; }
        public long? State { get; set; }
        public string Description { get; set; }
    }
}
