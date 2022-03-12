using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace SportClubFaratechno.Models.ViewModels.Filters
{
    public class FrontEndAuthorizationAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (Role!="")
            {

                var resLogin = context.HttpContext.Session.GetObject<LoginResponse>("Auth");


                //== "Admin";
                if (Role != resLogin.roles[0])
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Custom" },
                    { "action", "AccessError" }
                });
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
