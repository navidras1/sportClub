using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class TrafficCabinet
    {
        public long Id { get; set; }
        public long CabinetId { get; set; }
        public long TrafficId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }

    }
}
