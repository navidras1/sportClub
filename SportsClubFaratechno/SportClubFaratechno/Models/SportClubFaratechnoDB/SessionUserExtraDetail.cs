using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public partial class SessionUserExtraDetail
    {
        public long Id { get; set; }
        public long? SessionUserId { get; set; }
        public long? UserExtraDetailId { get; set; }
    }
}
