using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportClubFaratechno.Models;
using SportClubFaratechno.Models.ViewModels.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Controllers
{
    [FrontEndAuthentication]
    [FrontEndAuthorization(Role = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


       

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Definition()
        {
            return View();
        }
        
        public IActionResult Salon()
        {
            return View();
        }

        public IActionResult Sports()
        {
            return View();
        }

        public IActionResult Buffet()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Cabinet()
        {
            return View();
        }

        public IActionResult BuffetShop()
        {
            return View();
        }

        public IActionResult Transactions()
        {
            return View();
        }

    }
}
