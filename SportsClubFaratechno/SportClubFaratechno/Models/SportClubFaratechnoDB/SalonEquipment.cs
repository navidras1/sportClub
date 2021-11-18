using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public partial class SalonEquipment
    {
        public long Id { get; set; }
        public long? SalonId { get; set; }
        public string Equipment { get; set; }
        public int? Quantity { get; set; }
        public bool? IsFreeToUse { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
    }
}
