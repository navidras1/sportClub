using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.Models;
using SportClubFaratechno.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportClubFaratechno.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinetController : SportClubBaseController
    {

        


        /// <summary>
        /// ایجاد کمد
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost("CreateCabinet")]
        public IActionResult CreateCabinet(CreateCabinetModel model)
        {

            var res = SCP.CreateCabinet(model);

            return Ok(res);
        }

        /// <summary>
        /// حذف کمد
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("DeleteCabinet")]
        public IActionResult DeleteCabinet(List<long> ids)
        {

            var res = SCP.DeleteCabinet(ids);
            return Ok(res);
        }

        //public IActionResult ListOfCabibets()
        //{

        //    return Ok();
        //}

        //public IActionResult UpdateCabinet(long id , UpdateCabinetModel model)
        //{
        //    return Ok();
        //}

        /// <summary>
        /// انتساب کمد به کاربر
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AssignCabinetToUser")]
        public IActionResult AssignCabinetToUser(List<AssignCabinetToUserModel> model)
        {
           var res = SCP.AssignCabinetToUser(model);

            return Ok(res);
        }

        /// <summary>
        /// باز ستانی کمد از کاربر
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UnassignCabinetFromUser")]
        public IActionResult UnassignCabinetFromUser( List<AssignCabinetToUserModel> model)
        {
            var res = SCP.UnassignCabinetFromUser(model);

            return Ok(res);
        }

        /// <summary>
        /// لیست کمدها
        /// </summary>
        /// <param name="spc"></param>
        /// <returns></returns>
        [HttpPost("GetListOfCabinets")]
        public IActionResult GetListOfCabinets()
        {
          var res =  SCP.GetListOfCabinets();
          return Ok( res );
        }

        




        
        
    }
}
