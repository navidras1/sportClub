using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Filters
{
    public class AccessFilterAttribute: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userName = context.HttpContext.User.Identity.Name;

            var path = context.HttpContext.Request.Path.Value;

            SportClubFaratechnoDBContext sportClubDbContext = new SportClubFaratechnoDBContext();

            var theAccess = sportClubDbContext.Access.Where(pp => pp.WebApiAddress == path).FirstOrDefault();

            if (theAccess == null)
            {
                context.Result = new NotFoundObjectResult("دسترسی تعریف نشده است.");
                return;
            }

            var theUser = sportClubDbContext.Users.Where(pp => pp.UserName == userName).FirstOrDefault();
            var userRoles = sportClubDbContext.UserRoles.Where(pp => pp.UserId == theUser.Id).Select(pp => pp.RoleId).ToList();

            var RoleHasAccess = sportClubDbContext.RoleAccess.Any(pp => userRoles.Contains(pp.RoleId) && pp.AccessId == theAccess.Id);

            if (!RoleHasAccess)
            {
                context.Result = new UnauthorizedObjectResult("عدم دسترسی کاربر");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
