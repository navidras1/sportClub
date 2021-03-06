using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class ListOfTransactionsModel
    {
        public long? UserId { get; set; }
        public long? TrnType { get; set; }
        public decimal? Price { get; set; }
        public long? TrnSource { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
        public string TableName { get; set; }
        public bool? IncomeSpend { get; set; }
    }
}
