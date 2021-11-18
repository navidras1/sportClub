using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportClubFaratechno.Models.Repository;
using SportClubFaratechno.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportClubFaratechno.Controllers
{
    public class GeneralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAsync([FromBody] LoginModel model)
        {
            //var model = new { Username = UserName };

            HttpClient httpClient = new HttpClient();
            //httpClient.
            var obj = new
            {
                username = model.UserName,
                password = model.Passwrod
            };


            var scheme = Request.Scheme;
            var host = Request.Host.Value;

            var json = JsonConvert.SerializeObject(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = httpClient.PostAsync($"{scheme}://{host}/api/Authenticate/login", data).Result.Content.ReadAsStringAsync().Result;

            LoginResponse resObj = JsonConvert.DeserializeObject<LoginResponse>(res);

            var resObjClone = resObj.Clone();
            if (resObj.token != null)
            {
                //HttpContext.Session.SetString("token", resObj.token);
                HttpContext.Session.SetObject("Auth", resObj);
                //return RedirectToAction("index");
                resObjClone.token = "true";
            }
            else
            {
                resObjClone.token = "false";
            }
            
            return Json(resObjClone);
        }
    }
}
