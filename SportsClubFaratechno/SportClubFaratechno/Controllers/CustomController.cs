using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Controllers
{
    public class CustomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessError()
        {
            return View();
        }
    }
}
