using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class DetailType
    {
        public long Id { get; set; }
        public long? MasterId { get; set; }
        public string DetailName { get; set; }
        public string DetailValue { get; set; }
        public string Description { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }

    }
}
