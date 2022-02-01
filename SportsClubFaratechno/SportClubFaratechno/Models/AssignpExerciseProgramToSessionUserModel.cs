using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AssignpExerciseProgramToSessionUserModel
    {

        [Required(ErrorMessage = "لطفا شناسه دوره کاربر  را وارد کنید")]
        public long SessionUserId { get; set; }

        [Required(ErrorMessage = "لطفا برنامه را وارد کنید")]
        public string ExcerciseProgram { get; set; }
    }
}
