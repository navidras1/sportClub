using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public partial class SalonSportSessionType
    {
        public long Id { get; set; }
        //public long? SessionId { get; set; }
        public long? SalonSportId { get; set; }
        public string Description { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
    }
}
