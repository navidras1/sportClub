using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportClubFaratechno.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonSportController : SportClubBaseController
    {

        /// <summary>
        /// انتساب ورزش به سالن
        /// </summary>
        /// <returns></returns>
        [HttpPost("AssignSportToSalon")]
        public IActionResult AssignSportToSalon(AssignSportToSalonModel model)
        {

            var res = SCP.AssignSportToSalon(model);
            return Ok(res);
        }


        /// <summary>
        /// ویرایش سالن ورزش
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateSalonSport")]
        public IActionResult UpdateSalonSport(UpdateSalonSportModel model)
        {
            var res = SCP.UpdateSalonSport(model);
            return Ok(res);
        }
        /// <summary>
        /// حذف سالن ورزش
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteSalonSport")]
        public IActionResult DeleteSalonSport(long id)
        {
            var res = SCP.DeleteSalonSport(id);
            return Ok(res);
        }

        /// <summary>
        /// لیست سالن ورزش
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetListOfSportSalon")]
        public IActionResult GetListOfSportSalon()
        {
            var res = SCP.GetListOfSportSalon();
            return Ok(res);
        }


        /// <summary>
        /// انتساب دستگاه به سالن
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddSalonEqueepmet")]
        public IActionResult AddSalonEqueepmet(AddSalonEqueepmetModel model)
        {

            var res = SCP.AddSalonEqueepmet(model);
            return Ok(res);
        }

        /// <summary>
        /// لیست دستگاه ها
        /// </summary>
        /// <returns></returns>

        [HttpPost("ListOfSalonEqueepments")]
        public IActionResult ListOfSalonEqueepments()
        {
            var res = SCP.ListOfSalonEqueepments();
            return Ok(res);
        }

        /// <summary>
        /// ویرایش دستگاه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateEqueepment")]
        public IActionResult UpdateEqueepment(UpdateEqueepmentModel model)
        {

            var res = SCP.UpdateEqueepment(model);
            return Ok(res);
        }


        /// <summary>
        /// حذف دستگاه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteEqueepment")]
        public IActionResult DeleteEqueepment(long id)
        {
            var res = SCP.DeleteEqueepment(id);
            return Ok(res);
        }




        //[HttpPost("CreateSalonSportSessionType")]
        //public IActionResult CreateSalonSportSessionType(CreateSalonSportSessionTypeModel model)
        //{

        //    return null;

        //}

        // GET: api/<SalonSportController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SalonSportController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalonSportController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SalonSportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalonSportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
