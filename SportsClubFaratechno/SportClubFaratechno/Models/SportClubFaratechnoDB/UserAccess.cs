using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class UserAccess
    {
        public long Id { get; set; }
        public long AccessId { get; set; }
        public long UserId { get; set; }
        public bool HasAccess { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
    }
}
