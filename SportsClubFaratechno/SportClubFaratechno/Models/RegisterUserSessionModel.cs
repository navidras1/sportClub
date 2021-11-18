using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class RegisterUserSessionModel
    {

        
        [Required(ErrorMessage = "لطفا آی دی دوره را وارد کنید")]
        public long? SessionId { get; set; }

        public List<UserInfo> userInfoLst { get; set; }
        

    }

    public class UserInfo
    {
        [Required(ErrorMessage = "لطفا آی دی کاربر را وارد کنید")]
        public long? UserId { get; set; }
    }
}
