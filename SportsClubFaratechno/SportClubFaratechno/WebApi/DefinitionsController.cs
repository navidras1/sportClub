using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.Models;
using SportClubFaratechno.Models.Repository;
using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportClubFaratechno.WebApi
{/// <summary>
/// تعاریف
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionsController : SportClubBaseController
    {


        [HttpPost("CreateMasterType")]
        public IActionResult CreateMasterType(string Name)
        {
            var res = SCP.CreateMasterType(Name);
            return Ok(res);
        }
        /// <summary>
        /// اضافه کردن اقلام بوفه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateDetailBuffetItems")]
        public IActionResult CreateDetailBuffetItems(CreateDetailModel model)
        {
            var res = SCP.CreateDetailType("اقلام بوفه", model.DetailName, model.Description);

            return Ok(res);
        }
        /// <summary>
        /// مشاهده اقلام بوفه
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListOfBuffetItems")]
        public IActionResult ListOfBuffetItems()
        {
            var res = SCP.GetListOfDetails("اقلام بوفه");
            return Ok(res);
        }


        /// <summary>
        /// ویرایش اقلام بوفه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateBuffetItem(UpdateDetailModel model)
        {
            var res = SCP.UpdateDetails("اقلام بوفه", model.OldName, model.NewName);
            return Ok(res);
        }

        /// <summary>
        /// ایجاد باشگاه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateClub")]
        public IActionResult CreateClub(CreateDetailModel model)
        {
            var res = SCP.CreateDetailType("باشگاه", model.DetailName, model.Description);
            return Ok(res);
        }




        /// <summary>
        /// اضافه کردن سالن
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateDetailSalon")]
        public IActionResult CreateDetailSalon(CreateDetailModel model)
        {
            var res = SCP.CreateDetailType("سالن", model.DetailName, model.Description);
            return Ok(res);
        }

        /// <summary>
        /// مشاهده لیست سالن
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetSalonList")]
        public IActionResult GetSalonList()
        {
            var res = SCP.GetListOfDetails("سالن");
            return Ok(res);
        }

        /// <summary>
        /// مشاهده لیست باشگاه ها
        /// </summary>
        /// <returns></returns>

        [HttpPost("GetClubList")]
        public IActionResult GetClubList()
        {
            var res = SCP.GetListOfDetails("باشگاه");
            return Ok(res);
        }


        /// <summary>
        /// ویرایش سالن
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateSalon")]
        public IActionResult UpdateSalon(UpdateDetailModel model)
        {
            var res = SCP.UpdateDetails("سالن", model.OldName, model.NewName);
            return Ok(res);
        }


        /// <summary>
        /// ایجاد رشته ورزشی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateDetailSports")]
        public IActionResult CreateDetailSports(CreateDetailModel model)
        {
            var res = SCP.CreateDetailType("رشته ورزشی", model.DetailName, model.Description);
            return Ok(res);
        }

        /// <summary>
        /// مشاهده لیست رشته های ورزشی
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost("GetSportsList")]
        public IActionResult GetSportsList()
        {
            var res = SCP.GetListOfDetails("رشته ورزشی");
            return Ok(res);
        }
        /// <summary>
        /// ویرایش رشته ورزشی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("UpdateSports")]
        public IActionResult UpdateSports(UpdateDetailModel model)
        {
            var res = SCP.UpdateDetails("رشته ورزشی", model.OldName, model.NewName);
            return Ok(res);
        }

        /// <summary>
        /// ایجاد بوفه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateDetailBuffet")]
        public IActionResult CreateDetailBuffet(CreateDetailModel model)
        {
            var res = SCP.CreateDetailType("بوفه", model.DetailName, model.Description);
            return Ok(res);
        }
        /// <summary>
        /// مشاهده لیست بوفه ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetBuffetList")]
        public IActionResult GetBuffetList()
        {
            var res = SCP.GetListOfDetails("بوفه");
            return Ok(res);
        }


        /// <summary>
        /// ویرایش بوفه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateBuffet")]
        public IActionResult UpdateBuffet(UpdateDetailModel model)
        {
            var res = SCP.UpdateDetails("بوفه", model.OldName, model.NewName);
            return Ok(res);

        }

        /// <summary>
        /// ایجاد نوع کمد
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateDetailCabinetType")]
        public IActionResult CreateDetailCabinetType(CreateDetailModel model)
        {
            var res = SCP.CreateDetailType("کمد", model.DetailName, model.Description);
            return Ok(res);
        }

        /// <summary>
        /// مشاهده لیست نوع کمدها
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost("GetCabinetTypeList")]
        public IActionResult GetCabinetTypeList()
        {
            var res = SCP.GetListOfDetails("کمد");
            return Ok(res);
        }

        /// <summary>
        /// ویرایش نوع کمد
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateCabinetType")]
        public IActionResult UpdateCabinetType(UpdateDetailModel model)
        {
            var res = SCP.UpdateDetails("کمد", model.OldName, model.NewName);
            return Ok(res);
        }


        /// <summary>
        /// ایجاد نوع جنس بوفه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateBuffetItemType")]
        public IActionResult CreateBuffetItemType(CreateDetailModel model)
        {
            var res = SCP.CreateDetailType("نوع جنس بوفه", model.DetailName, model.Description);
            return Ok(res);
        }


        /// <summary>
        /// لیست نوع جنس بوفه
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetBuffetItemTypeList")]
        public IActionResult GetBuffetItemTypeList()
        {
            var res = SCP.GetListOfDetails("نوع جنس بوفه");
            var ss = ((List<DetailType>)res.Data);
            ss.Insert(0, new DetailType { Id = -1, DetailName = "همه موارد" });
            res.Data = ss;
            return Ok(res);
        }



        /// <summary>
        /// ویرایش نوع جنس بوفه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateBuffetItemType")]
        public IActionResult UpdateBuffetItemType(UpdateDetailModel model)
        {
            var res = SCP.UpdateDetails("نوع جنس بوفه", model.OldName, model.NewName);
            return Ok(res);
        }

        /// <summary>
        /// ایجاد نوع جلسه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateSessionType")]
        public IActionResult CreateSessionType(CreateDetailModel model)
        {
            var res = SCP.CreateDetailType("جلسه", model.DetailName, model.Description);
            return Ok(res);

        }


        /// <summary>
        /// لیست توع جلسات
        /// </summary>
        /// <returns></returns>

        [HttpPost("ListOfSessionTypes")]
        public IActionResult ListOfSessionTypes()
        {
            var res = SCP.GetListOfDetails("جلسه");
            return Ok(res);
        }

        /// <summary>
        /// ویرایش نوع دوره
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost("UpdateSessionType")]
        public IActionResult UpdateSessionType(UpdateDetailModel model)
        {
            var res = SCP.UpdateDetails("جلسه", model.OldName, model.NewName);
            return Ok(res);
        }


        /// <summary>
        /// لیست جنسیت
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListOfSessionSex")]
        public IActionResult ListOfSessionSex()
        {
            var res = SCP.GetListOfDetails("جنسیت");
            return Ok(res);
        }








    }
}
