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


        /// <summary>
        /// انتساب بوفه به سالن
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AssignBuffetToSalon")]
        public IActionResult AssignBuffetToSalon(AssignBuffetToSalonModel model)
        {
            var res = SCP.AssignBuffetToSalon(model);
            return Ok(res);
        }


        /// <summary>
        /// خرید از بوفه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("PurchaseItem")]
        public IActionResult PurchaseItem(PurchaseItemModel model)
        {
            var res = SCP.PurchaseItem(model);
            return Ok(res);
        }


        /// <summary>
        /// لیست بوفه های سالن
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetlistOfSalonBuffets")]
        public IActionResult GetlistOfSalonBuffets(GetlistOfSalonBuffetsModel model)
        {
            var res = SCP.GetlistOfSalonBuffets(model);
            return Ok(res);
        }

        /// <summary>
        /// انتساب جنس به نوع جنس
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AssignBuffetItemToBuffetItemType")]
        public IActionResult AssignBuffetItemToBuffetItemType(AssignBuffetItemToBuffetItemTypeModel model)
        {
            var res = SCP.AssignBuffetItemToBuffetItemType(model);
            return Ok(res);
        }

        /// <summary>
        /// لیست کالا بر اساس نوع و سالن
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetListOfItemsByTypeBySalon")]
        public IActionResult GetListOfItemsByTypeBySalon(GetListOfItemsByTypeByBuffetModel model)
        {
            var res = SCP.GetListOfItemsByTypeBySalon(model);
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
