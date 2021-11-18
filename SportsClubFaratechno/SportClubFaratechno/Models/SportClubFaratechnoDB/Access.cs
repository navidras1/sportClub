using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.SportClubFaratechnoDB
{
    public class Access
    {
        public long Id { get; set; }
        public string WebApiAddress { get; set; }

        public string Name { get; set; }

        public DateTime SubmissionDate { get; set; }

        public string SubmissionDateShamsi { get; set; }
    }
}
