using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public partial class Transaction
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? TrnType { get; set; }
        public decimal? Price { get; set; }
        public long? TrnSource { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
        [StringLength(100)]
        public string TableName { get; set; }
        public bool IncomeSpend { get; set; }
        public int Quantity { get; set; }
        public long? InvoiceId { get; set; }
    }
}
