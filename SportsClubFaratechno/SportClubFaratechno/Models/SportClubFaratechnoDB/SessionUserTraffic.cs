using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public partial class SessionUserTraffic
    {
        public long Id { get; set; }
        public long? SessionUserId { get; set; }
        public DateTime? EntranceDatetime { get; set; }
        public string EntranceDatetimeShamsi { get; set; }
        public DateTime? ExitDatetime { get; set; }
        public string ExitDatetimeShamsi { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
        public string Description { get; set; }
    }
}
