using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class EditRoleAccessModel
    {
        [Required(ErrorMessage = "لطفا آی دی را وارد کنید")]
        public long? Id { get; set; }


        public long? AccessId { get; set; }


        public long? RoleId { get; set; }
    }
}
