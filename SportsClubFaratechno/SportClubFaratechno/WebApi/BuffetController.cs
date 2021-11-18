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
    public class BuffetController : SportClubBaseController
    {

        /// <summary>
        /// اضافه کردن جنس به بوفه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddBuffetItem")]
        public IActionResult  AddBuffetItem(AddBuffetItemModel model)
        {
            var res = SCP.AddBuffetItem(model);
            return Ok(res);
        }
        /// <summary>
        /// ویرایش قیمت و تعداد جنس
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateBuffetItem")]
        public IActionResult UpdateBuffetItem(UpdateBuffetItemModel model)
        {
            var res = SCP.UpdateBuffetItem(model);
            return Ok(res);
        }
        /// <summary>
        /// حذف کالا
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("RemoveBuffetItem")]
        public IActionResult RemoveBuffetItem(long id)
        {
            var res = SCP.RemoveBuffetItem(id);
            return Ok(res);
        }

        // GET: api/<BuffetController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BuffetController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BuffetController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BuffetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BuffetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
