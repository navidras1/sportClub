using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.ViewModels.Filters
{
    public class FrontEndAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var ss= HttpContext.Session.GetObject<LoginResponse>();
            var ss = context.HttpContext.Session.GetObject<LoginResponse>("Auth");

            if (ss == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Login" }
                });
            }

            base.OnActionExecuting(context);
        }
    }
}
