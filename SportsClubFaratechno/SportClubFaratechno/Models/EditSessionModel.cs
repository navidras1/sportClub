using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class EditSessionModel
    {
        public long? Id { get; set; }
        public long? SalonSportId { get; set; }
        public int? NumberOfSessions { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartDateShamsi { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndDateShamsi { get; set; }
        public long? State { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Description { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? AtAprice { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }
        public long? Sex { get; set; }

        public int? NumberOfPeople { get; set; }
    }
}
