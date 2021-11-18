using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public partial class BuffetDetail
    {
        public long Id { get; set; }
        public long? BuffetId { get; set; }
        public long? BuffetItem { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
    }
}
