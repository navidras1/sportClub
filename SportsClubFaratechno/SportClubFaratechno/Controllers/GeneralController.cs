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

        public IActionResult Logout()
        {
            HttpContext.Session.SetObject("Auth", null);
            return Redirect("/Home/Index");
        }


        public IActionResult Dispatcher()
        {
            var resLogin = HttpContext.Session.GetObject<LoginResponse>("Auth");

            if (resLogin.roles[0] == "Admin")
            {

                return this.Redirect("/Home/Index");
            }
            else if(resLogin.roles[0] == "Member")
            {
                return Redirect("/User/Index");
            }
            else
            {
                return Redirect("");
            }
        }



        public IActionResult CallApi([FromBody] CallApiModel model)
        {

            HttpClient httpClient = new HttpClient();
            var scheme = Request.Scheme;
            var host = Request.Host.Value;
            string res;

            object obj = model.Model;

            if (obj != null)
            {
                var json = JsonConvert.SerializeObject(obj);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                res = httpClient.PostAsync($"{scheme}://{host}{model.Address}", data).Result.Content.ReadAsStringAsync().Result;


            }
            else
            {
                //var data = new StringContent(string.Empty);
                var data = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                res = httpClient.PostAsync($"{scheme}://{host}{model.Address}", data).Result.Content.ReadAsStringAsync().Result;
            }





            WebApiResponse resObj = JsonConvert.DeserializeObject<WebApiResponse>(res);

            return Ok(resObj);

        }



    }
}
