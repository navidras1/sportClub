using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.Models.ViewModels;
using SportClubFaratechno.Models.ViewModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Controllers
{

    [FrontEndAuthentication]
    [FrontEndAuthorization(Role = "Member")]
    public class User : Controller
    {
        public IActionResult Index()
        {

            var resLogin = HttpContext.Session.GetObject<LoginResponse>("Auth");
            return View(resLogin);
        }
        public IActionResult Transactions()
        {
            return View();
        }
    }
}
