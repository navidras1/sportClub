using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.ViewModels
{
    public class WebApiResponse
    {
            public bool HasError { get; set; } 
            public string Status { get; set; } 
            public string Message { get; set; } 

            public List<string> Warning { get; set; } = new List<string>();
            public object LogChanges { get; set; }
            public object Data { get; set; }
    }
}
