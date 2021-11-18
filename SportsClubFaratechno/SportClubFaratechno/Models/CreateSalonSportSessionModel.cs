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
        [Required(ErrorMessage = "لطفا تعداد جلسات را وارد کنید.")]
        public int? NumberOfSessions { get; set; }
        [Required(ErrorMessage = "لطفا تاریخ شروع دوره را وارد کنید.")]
        public string StartDateShamsi { get; set; }
        [Required(ErrorMessage = "لطفا تاریخ پایان دوره را وارد کنید.")]
        public string EndDateShamsi { get; set; }
        //public long? State { get; set; }

        [Required(ErrorMessage = "لطفا ساعت شروع را وارد کنید.")]
        public TimeSpan? StartTime { get; set; }
        [Required(ErrorMessage = "لطفا ساعت پایان را وارد کنید.")]
        public TimeSpan? EndTime { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "لطفا شهریه را وارد کنید.")]

        public decimal? TotalPrice { get; set; }
        public decimal? AtAprice { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string SubmissionDateShamsi { get; set; }

        [Required(ErrorMessage = "لطفا مردانه یا زنانه را وارد کنید.")]
        public bool? Sex { get; set; }

        public int? NumberOfPeople { get; set; }

    }
}
