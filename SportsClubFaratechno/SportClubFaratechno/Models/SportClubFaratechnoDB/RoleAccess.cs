using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class RoleAccess
    {
        public long Id { get; set; }
        public long AccessId { get; set; }

        public long RoleId { get; set; }

        public DateTime SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
    }
}
