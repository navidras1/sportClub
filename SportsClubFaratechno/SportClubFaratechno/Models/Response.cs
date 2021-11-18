using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class Response
    {
        public Response(string message)
        {
            Message = message;
        }
        public Response() { }
        public bool HasError { get; set; } = false;
        public string Status { get; set; } = "200";
        public string Message { get; set; } = "عملیات با موفقیت انجام شد.";

        public List<string> Warning { get; set; } = new List<string>();

        public object LogChanges { get; set; }
        public object Data { get; set; }
    }
}
