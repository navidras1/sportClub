using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class CreateSalonSportSessionModel
    {
        [Required(ErrorMessage = "لطفا آی دی سالن ورزش را وارد کنید.")]
        public long? SalonSportId { get; set; }
        
        public int? NumberOfSessions { get; set; }
        
        public string StartDateShamsi { get; set; }
        
        public string EndDateShamsi { get; set; }
        //public long? State { get; set; }

        [Required(ErrorMessage = "لطفا ساعت شروع را وارد کنید.")]
        public TimeSpan? StartTime { get; set; }
        [Required(ErrorMessage = "لطفا ساعت پایان را وارد کنید.")]
        public TimeSpan? EndTime { get; set; }
        public string Description { get; set; }
        
        public decimal? TotalPrice { get; set; }
        public decimal? AtAprice { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }

        
        public long? Sex { get; set; }

        public int? NumberOfPeople { get; set; }

        public long SessionTypeId { get; set; }

    }
}
