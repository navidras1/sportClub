using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportClubFaratechno.ComponentsLibrary;
using SportClubFaratechno.Models;
using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportClubFaratechno.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly SportClubFaratechnoDBContext sportClubFaratechnoDBContext;


        public AuthenticateController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IConfiguration configuration, SportClubFaratechnoDBContext dbContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            this.sportClubFaratechnoDBContext = dbContext;
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            var result = await userManager.CheckPasswordAsync(user, model.Password);
            if (user != null && result)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),

                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var theRoles = sportClubFaratechnoDBContext.Roles.Where(pp => userRoles.Contains(pp.Name)).ToList();

                var theAccessRoles = from i in theRoles
                                     join j in sportClubFaratechnoDBContext.RoleAccess on i.Id equals j.RoleId
                                     join k in sportClubFaratechnoDBContext.Access on j.AccessId equals k.Id
                                     select k;



                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    Roles = userRoles,
                    AccessRoles = theAccessRoles.ToList()

                });
            }
            else
            {

            }

            return Unauthorized();
        }

        



        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status406NotAcceptable, new Response { Status = "Error", Message = "نام کاربری تکراریست!" });



            AppUser user = new AppUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
           
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                //return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "پسورد وارد شده قابل قبول نیست! پسورد قابل قبول شامل عدد، علامت و حرف میباشد." });
                return StatusCode(StatusCodes.Status406NotAcceptable, result.Errors);
            }
            //
            return Ok(new Models.Response { Status = "Success", Message = "ساخت کاربر با موفقیت انجام شد!" , Data = new {userId= user.Id } });
        }

        
        



        /// <summary>
        /// ساخت نقش کاربر
        /// </summary>
        /// <param name="identityRole"> مدل دارای پارامتر 
        /// rolename </param>
        /// <returns> در صورت تایید بازگشت کد 200 و
        /// در غیر این صورت بازگشت کد 302 یا 406</returns>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("createRole")]
        public async Task<IActionResult> CreateRole([FromBody] IdentityRoleModel identityRole)
        {

            var roleExists = await roleManager.FindByNameAsync(identityRole.RoleName);
            if (roleExists != null)
            {
                return StatusCode(StatusCodes.Status302Found, new Response { Status = "Error", Message = "نقش وارد شده از قبل موجود است." });
            }

            var result = await roleManager.CreateAsync(new AppRole { Name = identityRole.RoleName, NormalizedName = identityRole.RoleName.ToUpper(), ConcurrencyStamp = new Guid().ToString() });
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new Response { Status = "Error", Message = "نقش مورد نظر ایجاد نشد لطفا با آدمین تماس بگیرید." });
            }

            return Ok(new Response { Status = "Success", Message = "نقش با موفقیت ایجاد شد." });
        }

        /// <summary>
        /// تخصیص نقش به هر کاربر
        /// </summary>
        /// <param name="roleUserModel"> مدلی شامل نام کاربر و نام نقش کاربر </param>
        /// <returns> تایید 200
        /// عدم تایید 404 یا 406 </returns>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("assignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUser(RoleUserModel roleUserModel)
        {
            var userExists = await userManager.FindByNameAsync(roleUserModel.UserName);
            if (userExists == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "نام کاربری وارد شده موجود نیست." });
            }
            var roleExists = await roleManager.FindByNameAsync(roleUserModel.RoleName);
            if (roleUserModel == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "نقش وارد شده موجود نیست." });
            }

            var res = await userManager.AddToRoleAsync(userExists, roleUserModel.RoleName);


            if (!res.Succeeded)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new Response { Status = "Error", Message = "نقش مورد نظر به کاربر منتسب نشد لطفا با آدمین تماس بگیرید." });
            }
            return Ok(new Response { Status = "Success", Message = "نقش با موفقیت به کاربر منتسب شد." });
        }

        /// <summary>
        /// حذف نقش تخصیص داده شده به کاربر از کاربر
        /// </summary>
        /// <param name="roleUserModel"> مدلی شامل نام کاربر و نام نقش کاربر  </param>
        /// <returns> تایید 200
        ///  عدم تایید 304 و 404 </returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("removeRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser(RoleUserModel roleUserModel)
        {


            var userExists = await userManager.FindByNameAsync(roleUserModel.UserName);
            if (userExists == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "نام کاربری وارد شده موجود نیست." });
            }


            var roleExists = await roleManager.FindByNameAsync(roleUserModel.RoleName);
            if (roleUserModel == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "نقش وارد شده موجود نیست." });
            }

            if (userExists.UserName.ToLower() == "admin" && roleUserModel.RoleName.ToLower() == "admin")
            {
                return StatusCode(StatusCodes.Status304NotModified, new Response { Status = "Error", Message = "نقش مدیریت کاربر ادمین قابل تغییر نیست." });

            }

            var res = await userManager.RemoveFromRoleAsync(userExists, roleUserModel.RoleName);


            if (!res.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "نقش مورد نظر به کاربر منتسب نشد لطفا با آدمین تماس بگیرید." });
            }
            return Ok(new Response { Status = "Success", Message = "نقش با موفقیت از کاربر گرفته  شد." });
        }

        /// <summary>
        /// تغییر 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("resetPasswordByAdmin")]
        public async Task<IActionResult> ResetPasswordByAdmin([FromBody] LoginModel model)
        {
            var identityUser = await userManager.FindByNameAsync(model.Username);

            var token = await userManager.GeneratePasswordResetTokenAsync(identityUser);
            var res = await userManager.ResetPasswordAsync(identityUser, token, model.Password);
            if (!res.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "خطا! تغییر رمز کاربر مورد نظر با خطا مواجه شد. لطفا با ادمین تماس بگیرید." });

            }

            return Ok(new Response { Status = "Success", Message = $"رمز کاربر با موفقیت تغییر یافت." });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("changePasswordByUser")]
        public async Task<IActionResult> ChangePasswordByUser(LoginChangePasswordModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var res = await userManager.ResetPasswordAsync(user, token, model.NewPassword);
                if (!res.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "خطا! تغییر رمز کاربر مورد نظر با خطا مواجه شد. لطفا با ادمین تماس بگیرید." });

                }

                return Ok(new Response { Status = "Success", Message = $"رمز  کاربر{model.Username} با موفقیت تغییر یافت." });
            }
            return Unauthorized();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("listOfRoles")]
        public IActionResult ListOfRoles()
        {
            var res = roleManager.Roles.Select(pp => new { id = pp.Id, RoleName = pp.Name }).ToList();

            Models.Response response = new Models.Response();
            response.Data = res;

            return Ok(response);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("listOfUsers")]
        public IActionResult ListOfUsersAsync()
        {
            var users = userManager.Users.ToList();
            var res = users.Select(pp => new { id = pp.Id, userName = pp.UserName, role = string.Join(',', userManager.GetRolesAsync(pp).Result.ToList()), Email = pp.Email, Phone = pp.PhoneNumber });

            Models.Response response = new Response();
            response.Data = res;

            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RegisterAccess")]
        public IActionResult RegisterAccess(RegisterAccessModel model)
        {
            var theAccess = sportClubFaratechnoDBContext.Access.Where(pp => pp.WebApiAddress == model.WebApiAddress || pp.Name == model.Name).FirstOrDefault();

            if (theAccess != null)
            {
                return StatusCode(StatusCodes.Status302Found, new Response { Status = "Error", Message = "دسترسی تکراری است." });
            }

            sportClubFaratechnoDBContext.Access.Add(new Access { WebApiAddress = model.WebApiAddress, Name = model.Name, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });
            sportClubFaratechnoDBContext.SaveChanges();

            return Ok(new Response { Status = "Success", Message = "دسترسی با موفقیت ایجاد شد." });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListOfAccesses")]
        public IActionResult ListOfAccesses()
        {
            var res = sportClubFaratechnoDBContext.Access.ToList();

            return Ok(res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("EditAccess")]
        public IActionResult EditAccess(EditAccessModel model)
        {
            var foundAccess = sportClubFaratechnoDBContext.Access.Find(model.Id);
            if (foundAccess == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "دسترسی مورد نظر یافت نشد." });
            }

            foundAccess.Name = model.Name ?? foundAccess.Name;
            foundAccess.WebApiAddress = model.WebApiAddress ?? foundAccess.WebApiAddress;
            sportClubFaratechnoDBContext.SaveChanges();

            return Ok(new Response { Status = "Success", Message = "ویرایش با موفقیت ایجاد شد." });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RegisterUserAccess")]
        public async Task<IActionResult> RegisterUserAccessAsync(RegisterUserAccessModel model)
        {

            var theUser = await userManager.FindByNameAsync(model.UserName);

            if (theUser == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "کاربر مورد نظر جستجو نشد." });
            }

            var theAccess = sportClubFaratechnoDBContext.Access.Find(model.AccessId);
            if (theAccess == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "دسترسی مورد نظر جستجو نشد." });
            }




            sportClubFaratechnoDBContext.UserAccess.Add(new UserAccess { AccessId = model.AccessId.Value, HasAccess = model.HasAccess.Value, UserId = theUser.Id, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });
            sportClubFaratechnoDBContext.SaveChanges();
            return Ok(new Response { Status = "Success", Message = "دسترسی کاربر ایجاد شد." });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("EditUserAccess")]
        public IActionResult EditUserAccess(EditUserAccessModel model)
        {
            var theUserAccess = sportClubFaratechnoDBContext.UserAccess.Find(model.Id);

            theUserAccess.HasAccess = model.HasAccess.Value;
            sportClubFaratechnoDBContext.SaveChanges();

            return Ok(new Response { Status = "Success", Message = "ویرایش دسترسی کاربر با موفقیت انجام شد." });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RegisterRoleAccess")]
        public async Task<IActionResult> RegisterRoleAccessAsync(RegisterRoleAccessModel model)
        {

            var theAccess = await sportClubFaratechnoDBContext.Access.FindAsync(model.AccessId);
            if (theAccess == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "دسترسی جستجو نشد." });
            }


            var theRole = await roleManager.FindByIdAsync(model.RoleId.ToString());
            if (theRole == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "نقش جستجو نشد." });
            }

            sportClubFaratechnoDBContext.RoleAccess.Add(new RoleAccess { AccessId = model.AccessId.Value, RoleId = model.RoleId.Value });

            sportClubFaratechnoDBContext.SaveChanges();

            return Ok(new Response { Status = "Success", Message = "دسترسی نقش با موفقیت ایجاد شد." });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListOfAccessRoll")]
        public IActionResult ListOfAccessRoll()
        {

            var res = (from i in sportClubFaratechnoDBContext.Access
                       join j in sportClubFaratechnoDBContext.RoleAccess on i.Id equals j.AccessId
                       join k in sportClubFaratechnoDBContext.Roles on j.RoleId equals k.Id

                       select new { Access = i, Role = k }).ToList();

            List<AccessRoleResultModel> accessRoleResultModels = new List<AccessRoleResultModel>();

            foreach (var i in res)
            {
                var tmpres = accessRoleResultModels.Any(pp => pp.Access.Id == i.Access.Id);

                if (!tmpres)
                {
                    AccessRoleResultModel cc = new AccessRoleResultModel();
                    cc.Access = i.Access;
                    cc.AppRoles = new List<AppRole>() { i.Role };
                    accessRoleResultModels.Add(cc);
                }
                else
                {
                    var tmp = accessRoleResultModels.Where(pp => pp.Access.Id == i.Access.Id).FirstOrDefault();
                    tmp.AppRoles.Add(i.Role);
                }


            }



            return Ok(accessRoleResultModels);
        }


        //[HttpPost("ListOfRollAccess")]
        //public IActionResult ListOfRollAccess()
        //{

        //    var res = (from i in sportClubFaratechnoDBContext.Access
        //               join j in sportClubFaratechnoDBContext.RoleAccess on i.Id equals j.AccessId
        //               join k in sportClubFaratechnoDBContext.Roles on j.RoleId equals k.Id

        //               select new { Access = i, Role = k }).ToList();

        //    List<AccessRoleResultModel> accessRoleResultModels = new List<AccessRoleResultModel>();

        //    foreach (var i in res)
        //    {
        //        var tmpres = accessRoleResultModels.Any(pp => pp.Access.Id == i.Access.Id);

        //        if (!tmpres)
        //        {
        //            AccessRoleResultModel cc = new AccessRoleResultModel();
        //            cc.Access = i.Access;
        //            cc.AppRoles = new List<AppRole>() { i.Role };
        //            accessRoleResultModels.Add(cc);
        //        }
        //        else
        //        {
        //            var tmp = accessRoleResultModels.Where(pp => pp.Access.Id == i.Access.Id).FirstOrDefault();
        //            tmp.AppRoles.Add(i.Role);
        //        }


        //    }



        //    return Ok(accessRoleResultModels);
        //}

        [HttpPost("ListOfRoleAccess")]
        public IActionResult ListOfRoleAccess()
        {

            var res = (from i in sportClubFaratechnoDBContext.Access
                       join j in sportClubFaratechnoDBContext.RoleAccess on i.Id equals j.AccessId
                       join k in sportClubFaratechnoDBContext.Roles on j.RoleId equals k.Id

                       select new { Access = i, Role = k }).ToList();

            List<RoleAccessResultModel> roleAccessResultModels = new List<RoleAccessResultModel>();

            foreach (var i in res)
            {
                var tmpres = roleAccessResultModels.Any(pp => pp.AppRole.Id == i.Role.Id);

                if (!tmpres)
                {
                    RoleAccessResultModel cc = new RoleAccessResultModel();
                    cc.AppRole = i.Role;
                    cc.Accesses = new List<Access>() { i.Access };
                    roleAccessResultModels.Add(cc);
                }
                else
                {
                    var tmp = roleAccessResultModels.Where(pp => pp.AppRole.Id == i.Role.Id).FirstOrDefault();
                    tmp.Accesses.Add(i.Access);
                }


            }



            return Ok(roleAccessResultModels);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("EditRoleAccess")]
        public async Task<IActionResult> EditRoleAccessAsync(EditRoleAccessModel model)
        {

            var theRoleAccess = sportClubFaratechnoDBContext.RoleAccess.Find(model.Id);
            if (theRoleAccess == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "سطح دسترسی نقش جستجو نشد." });
            }

            if (model.RoleId != null)
            {
                var theRole = await roleManager.FindByIdAsync(model.RoleId.ToString());
                if (theRole == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "نقش جستجو نشد." });
                }
            }

            if (model.AccessId != null)
            {

                var theAccess = sportClubFaratechnoDBContext.Access.Find(model.AccessId);
                if (theRoleAccess == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "دسترسی جستجو نشد." });

                }
            }

            theRoleAccess.AccessId = model.AccessId ?? theRoleAccess.AccessId;
            theRoleAccess.RoleId = model.RoleId ?? theRoleAccess.RoleId;
            sportClubFaratechnoDBContext.SaveChanges();

            return Ok(new Response { Status = "Success", Message = "دسترسی نقش با موفقیت انجام شد." });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("RemoveRoleAccessAsync")]
        public async Task<IActionResult> RemoveRoleAccessAsync(long id)
        {

            var theRoleAccess = await sportClubFaratechnoDBContext.RoleAccess.FindAsync(id);

            if (theRoleAccess == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "دسترسی جستجو نشد." });
            }

            sportClubFaratechnoDBContext.Remove(theRoleAccess);
            sportClubFaratechnoDBContext.SaveChanges();

            return Ok(new Response { Status = "Success", Message = "حذف با موفقیت انجام شد." });

        }


    }
}
