using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportClubFaratechno.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController : SportClubBaseController
    {


        [HttpPost("GetSalonDetails")]
        public IActionResult GetSalonDetails(GetSalonDetailsModel model)
        {
            var res = SCP.GetSalonDetails(model);
            return Ok(res);

        }

        [HttpPost("UpdateSalon")]
        public IActionResult UpdateSalon(UpdateSalonModel model)
        {

            var res = SCP.UpdateSalon(model);
            return Ok(res);
        }

        // GET: api/<SalonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SalonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalonController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<SalonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<SalonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
