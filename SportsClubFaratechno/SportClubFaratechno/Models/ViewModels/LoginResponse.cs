using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.ViewModels
{
    public class LoginResponse
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public List<string> roles { get; set; }
        public List<object> accessRoles { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
    }
}
