using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.ComponentsLibrary;
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
    public class SessionController : SportClubBaseController
    {
        /// <summary>
        /// ایجاد دوره
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateSession")]
        public IActionResult CreateSession(CreateSalonSportSessionModel model)
        {
            var res = SCP.CreateSession(model);
            return Ok(res);
        }

        /// <summary>
        /// ویرایش دوره
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("EditSession")]
        public IActionResult EditSession(EditSessionModel model)
        {
            var res = SCP.EditSession(model);
            return Ok(res);
        }


        /// <summary>
        /// لیست دوره ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListOfSessions")]
        public IActionResult ListOfSessions()
        {
            var res = SCP.ListOfSessions();
            return Ok(res);
        }


        /// <summary>
        /// لیست دوره های مربوط به ورزش سالن
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ListOfSessionsBySalonSportId")]
        public IActionResult ListOfSessionsBySalonSportId(ListOfSessionsBySalonSportIdModel model)
        {
            var res =SCP.ListOfSessionsBySalonSportId(model);
            return Ok(res);
        }



        /// <summary>
        /// حذف دوره
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost("DeleteSession")]
        public IActionResult DeleteSession(long id)
        {

            var res = SCP.DeleteSession(id);
            return Ok(res);
        }

        /// <summary>
        /// تعریف جلسات جهت دوره خاص
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateSessionDetail")]
        public IActionResult CreateSessionDetail(CreateSessionDetailModel model)
        {
            var res = SCP.CreateSessionDetail(model);
            return Ok(res);
        }


        /// <summary>
        /// ویرایش جلسه دوره
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("EditSessionDetail")]
        public IActionResult EditSessionDetail(EditSessionDetailModel model)
        {
            var res = SCP.EditSessionDetail(model);
            return Ok(res);
        }

        /// <summary>
        /// حذف جلسه دوره
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteSesssionDetail")]
        public IActionResult DeleteSesssionDetail(long id)
        {
            var res = DeleteSesssionDetail(id);
            return Ok(res);
        }

        /// <summary>
        /// ثبت نام کاربر 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RegisterUserSession")]
        public IActionResult RegisterUserSession(RegisterUserSessionModel model)
        {
            var res = SCP.RegisterUserSession(model);
            return Ok(res);
        }

        /// <summary>
        /// لیست کاربران شرکت کننده در دوره
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetListOfSessionUsersBySessionId")]
        public IActionResult GetListOfSessionUsersBySessionId(GetListOfSessionUsersBySessionIdModel model)
        {
            var res = SCP.GetListOfSessionUsersBySessionId(model);
            return Ok(res);

        }


        /// <summary>
        /// لیست دوره های کاربر 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetListOfSessionUsersByUserId")]
        public IActionResult GetListOfSessionUsersByUserId(GetListOfSessionUsersByUserIdModel model)
        {
            var res = SCP.GetListOfSessionUsersByUserId(model);
            return Ok(res);
        }




        /// <summary>
        /// ویرایش کاربر دوره
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateUserSession")]
        public IActionResult UpdateUserSession(UpdateUserSessionModel model)
        {
            var res = UpdateUserSession(model);
            return Ok(res);
        }


        /// <summary>
        /// حذف کاربر دوره
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteUserSession")]
        public IActionResult DeleteUserSession(long id)
        {
            var res = SCP.DeleteUserSession(id);
            return Ok(res);
        }

        /// <summary>
        /// انتساب برنامه به کاربر
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AssignpExerciseProgramToSessionUser")]
        public IActionResult AssignpExerciseProgramToSessionUser(AssignpExerciseProgramToSessionUserModel model)
        {
            var res = SCP.AssignpExerciseProgramToSessionUser(model);
            return Ok(res);
        }

        

        /// <summary>
        /// حذف برنامه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("DeleteUserExercise")]
        public IActionResult DeleteUserExercise(DeleteUserExerciseModel model)
        {
            var res = DeleteUserExercise(model);
            return Ok(res);
        }


        




        /// <summary>
        /// ورود کاربر 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("EnterSessionUserTraffic")]
        public IActionResult EnterSessionUserTraffic(EnterSessionUserTrafficModel model)
        {
            var res = SCP.EnterSessionUserTraffic(model);
            return Ok(res);
        }

        /// <summary>
        /// خروج کاربر
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ExitSessionTraffic")]
        public IActionResult ExitSessionTraffic(ExitSessionTrafficModel model)
        {
            var res = SCP.ExitSessionTraffic(model);
            return Ok(res);
        }


        /// <summary>
        /// دریافت شناسه کمد از طریق شناسه ترافیک
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetTrafficCabinetByTrafficId")]
        public IActionResult GetTrafficCabinetByTrafficId(GetTrafficCabinetByTrafficIdModel model)
        {
            var res = SCP.GetTrafficCabinetByTrafficId(model);
            return Ok(res);
        }


        /// <summary>
        /// ثبت کمد کاربر دوره
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("InsertTrafficCabinet")]
        public IActionResult InsertTrafficCabinet(InsertTrafficCabinetModel model)
        {
            var res = SCP.InsertTrafficCabinet(model);
            return Ok(res);
        }


        /// <summary>
        /// لیست ترافیک کاربر
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetUserTraffic")]
        public IActionResult GetUserTraffic(GetUserTrafficModel model)
        {
            var res = SCP.GetUserTraffic(model);
            return Ok(res);
        }


        [HttpPost("DeleteSessionUserTraffic")]
        public IActionResult DeleteSessionUserTraffic(long id)
        {
            var res = SCP.DeleteSessionUserTraffic(id);
            return Ok(res);
        }



        







        // GET: api/<SessionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {


            return new string[] { "value1", "value2" };
        }

        // GET api/<SessionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SessionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SessionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SessionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
