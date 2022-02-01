using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : SportClubBaseController
    {
        /// <summary>
        /// تعریف باشگاه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RegisterClub")]
        public IActionResult RegisterClub(RegisterClubModel model)
        {
            var res = SCP.RegisterClub(model);
           return  Ok(res);
        }

        /// <summary>
        /// انتساب سالن به باشگاه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AssignClubToSalon")]
        public IActionResult AssignSalonToClub(AssignSalonToClubModel model)
        {

            var res = SCP.AssignSalonToClub(model);
            return Ok(res);
        }

        /// <summary>
        /// انتساب کمد به باشگاه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("AssignCabinToClub")]
        public IActionResult AssignCabinToClub(AssignCabinToClubModel model)
        {
            var res = SCP.AssignCabinToClub(model);
            return Ok(res);
        }

        /// <summary>
        /// لیست سالن بر اساس شناسه باشگاه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetSalonListByClubId")]
        public IActionResult GetSalonListByClubId(GetSalonListByClubIdModel model)
        {
            var res = SCP.GetSalonListByClubId(model);
            return Ok(res);
        }

    }
}
