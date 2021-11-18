using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class TransactionInsertModel
    {
        public long? UserId { get; set; }
        public long? TrnType { get; set; }
        public decimal? Price { get; set; }
        public long? TrnSource { get; set; }
        public string Description { get; set; }
    }
}
