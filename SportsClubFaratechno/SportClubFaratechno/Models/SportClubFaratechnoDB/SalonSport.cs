using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public partial class SalonSport
    {
        public long Id { get; set; }
        public long? SalonTypeId { get; set; }
        public long? SportTypeId { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
        public string Desctiption { get; set; }
        public bool? SalonCabinetPrioraty { get; set; }
    }
}
