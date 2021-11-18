using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class UpdateUserSessionModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? SessionId { get; set; }
    }
}
