using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class CreateSessionDetailModel
    {
        public long? SessionId { get; set; }
        public List<SessionDetailItems> sessionDetailItems { get; set; }
        
    }

    public class SessionDetailItems
    {
        public DateTime? SessionDate { get; set; }
        public string SessionDateShamsi { get; set; }
        public long? State { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
        public string Description { get; set; }
    }
}
