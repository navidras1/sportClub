using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class SessionUserExerciseProgram
    {
        public long Id { get; set; }
        public long SessionUserId { get; set; }
        [StringLength(3000)]
        public string ExcerciseProgram { get; set; }

        public string SubmissionDateShamsi { get; set; }

        public DateTime SubmissionDate { get; set; }
    }
}
