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
    public class TransactionController : SportClubBaseController
    {


        /// <summary>
        /// ثبت تراکنش 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("TransactionInsert")]
        public IActionResult TransactionInsert(TransactionInsertModel model)
        {
            var res = SCP.TransactionInsert(model);
            return Ok(res);
        }

        /// <summary>
        /// لیست تراکنش ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListOfTransactions")]
        public IActionResult ListOfTransactions()
        {
            var res = SCP.ListOfTransactions();
            return Ok(res);
        }


        /// <summary>
        /// ثبت بیمه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RegisterUserInsurance")]
        public IActionResult  RegisterUserInsurance(RegisterUserInsuranceModel model)
        {
            var res = SCP.RegisterUserInsurance(model);
            return Ok(res);
        }

        /// <summary>
        /// بیمه کاربر
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UserInsurance")]
        public IActionResult UserInsurance(UserInsuranceModel model)
        {
            var res = SCP.UserInsurance(model);
            return Ok(res);
        }

        /// <summary>
        /// لیست بیمه 
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListofInsurance")]
        public IActionResult ListofInsurance()
        {
            var res = SCP.ListofInsurance();
            return Ok(res);
        }



        //public IActionResult ListOfTransactins()
        //{

        //}




        // GET: api/<TransactionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransactionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
