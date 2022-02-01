using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SportClubFaratechno.ComponentsLibrary;
using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SportClubFaratechno.Models
{
    public class Seed
    {
        //private readonly IServiceProvider _serviceProvider;
        //public Seed (IServiceProvider serviceProvider)
        //{
        //    _serviceProvider = serviceProvider;
        //}




        //public IServiceProvider serviceProvider()
        //{
        //    return _serviceProvider;
        //}
        private static IServiceProvider serviceProvider;

        public static SportClubFaratechnoDBContext SportClubFaratechnoDBContext
        {
            get
            {
                var options = TheServiceProvider.Instance.GetService<DbContextOptions<SportClubFaratechnoDBContext>>();

                return new SportClubFaratechnoDBContext(options);
            }

        }

        public static SportClubFaratechnoDBContext CreateDbCntx()
        {
            var options = TheServiceProvider.Instance.GetService<DbContextOptions<SportClubFaratechnoDBContext>>();

            return new SportClubFaratechnoDBContext(options);
        }


        public static void MigrateAndSeed()
        {
            var theSportClubFaratechnoDBContext = TheServiceProvider.Instance.GetService<SportClubFaratechnoDBContext>();

           //theSportClubFaratechnoDBContext.Database.exec
;            //var theSportClubFaratechnoDBContext = SportClubFaratechnoDBContext;
            theSportClubFaratechnoDBContext.Database.Migrate();
            var Now = DateTime.Now;
            var PNow = PersianDate.NowGetWithSlash;
            //theSportClubFaratechnoDBContext.Database.


            if (theSportClubFaratechnoDBContext.MasterType.Count() == 0)
            {

                List<MasterType> masterTypes = new List<MasterType>();
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "سالن", TypeId = "1" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "رشته ورزشی", TypeId = "2" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "تراکنش", TypeId = "3" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "جلسه", TypeId = "4" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "بوفه", TypeId = "5" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "اقلام بوفه", TypeId = "6" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "کمد", TypeId = "7" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "وضعیت دوره", TypeId = "8" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "وضعیت جلسه", TypeId = "9" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "باشگاه", TypeId = "10" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "نوع جنس بوفه", TypeId = "11" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "نوع جلسه", TypeId = "12" });
                masterTypes.Add(new MasterType { SubmissionDate = Now, SubmissionDateShamsi = PNow, TypeName = "جنسیت", TypeId = "13" });


                SportClubRepository<MasterType> sportClubRepositoryMasterType = new SportClubRepository<MasterType>();
                SportClubReposDI<MasterType>.OBJ.AddRange(masterTypes);
            }

            if (theSportClubFaratechnoDBContext.DetailType.Count() == 0)
            {
                List<DetailType> detailTypes = new List<DetailType>() {
                        //new DetailType{MasterId=1,DetailName="سالن یک",DetailValue="1",Description="سالن شماره یک",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=1,DetailName=" استخر یک ",DetailValue="2",Description="استخر شماره یک",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=2,DetailName="بدنساری",DetailValue="1",Description="رشته ورزشی بدنسازی",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=2,DetailName="کاراته",DetailValue="2",Description="رشته ورزشی کاراته",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType{MasterId=4,DetailName="سانس بسته شده",DetailValue="1",Description="سانس هایی که تعداد جلسات مشخص است و در صورت نیامدن هنر جو از جلسه سوخت میشود و از اعتبار هنر جو کم میشود",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType{MasterId=4,DetailName="سانس باز ",DetailValue="2",Description="سانس هایی که تعداد جلسات مشخص است و در صورت حضور هنرجو از اعتبار کاسته میشود",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType{MasterId=4,DetailName="سانس آزاد",DetailValue="3",Description="سانس یک جلسه ای برای هنرجویان بدون برنامه ریزی",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=5,DetailName="بوفه شماره یک",DetailValue="1",Description="بوفه شماره یک شامل اسنک گرم و تنقلات میباشد",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=6,DetailName="چیپس مزمز موکتی",DetailValue="1",Description="چیپس مزمز موکتی",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=6,DetailName="شیر موز",DetailValue="2",Description="شیر موز",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=6,DetailName="ساندویچ همبرگر",DetailValue="3",Description="ساندویچ همبرگر",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=7,DetailName="کمد قفل ساده",DetailValue="1",Description="کمد با قفل ساده ",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType{MasterId=7,DetailName="کمد با قفل الکترونیکی",DetailValue="2",Description="کمد با قفل الکترونیکی",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType{MasterId=3,DetailName="دریافت شهریه",DetailValue="1",Description="دریافت شهریه توسط باشگاه بها ازای هر دوره",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType{MasterId=3,DetailName="خرید از بوفه",DetailValue="2",Description="خرید جنس از بوفه",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType{MasterId=8,DetailName="شروع شده",DetailValue="1",Description="جلسات شروع شده و در حال اجرا میباشد",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType{MasterId=8,DetailName="به اتمام رسیده",DetailValue="2",Description="اتمام دوره ورزشی",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType{MasterId=8,DetailName="توقف جلسات",DetailValue="3",Description="توقف جلسات به علل مختلف و ادامه به بعد موکول میشود",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        //new DetailType {MasterId=10 , DetailName="باشگاه یک"  , DetailValue = "1" , Description="باشگاه شماره یک"  , SubmissionDate= DateTime.Now , SubmissionDateShamsi = PersianDate.NowGetWithSlash},
                        new DetailType {MasterId=8,DetailName="در انتظار برگزاری",DetailValue="4",Description="دوره هنوز برگزار نشده است. ",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType {MasterId=13,DetailName="آقایان",DetailValue="1",Description="سانس مربوط به آقایان",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType {MasterId=13,DetailName="بانوان",DetailValue="2",Description="سانس مربوط به بانوان",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash},
                        new DetailType {MasterId=13,DetailName="مختلط",DetailValue="3",Description="سانس مختلط",SubmissionDate=DateTime.Now,SubmissionDateShamsi=PersianDate.NowGetWithSlash}




                };

                SportClubReposDI<DetailType>.OBJ.AddRange(detailTypes);
            }


            if (theSportClubFaratechnoDBContext.Users.Count() == 0)
            {

                //var userManager = TheServiceProvider.Instance.GetService<UserManager<AppUser>>();

                using (var scope = TheServiceProvider.Instance.CreateScope())
                {
                    var userManager = (UserManager<AppUser>)scope.ServiceProvider.GetService(typeof(UserManager<AppUser>));
                    var roleManager = (RoleManager<AppRole>)scope.ServiceProvider.GetService(typeof(RoleManager<AppRole>));

                    dynamic res = null;
                    List<AppRole> appRoles = new List<AppRole>() {
                        new AppRole { Name = "Admin",ConcurrencyStamp = Guid.NewGuid().ToString() },
                        new AppRole { Name = "Member", ConcurrencyStamp = Guid.NewGuid().ToString() },
                        new AppRole { Name = "Trainer", ConcurrencyStamp = Guid.NewGuid().ToString() },
                        new AppRole { Name = "Cabinet",  ConcurrencyStamp = Guid.NewGuid().ToString() }
                    };

                    foreach (var i in appRoles)
                    {
                        res = roleManager.CreateAsync(i).Result;
                    }

                    AppUser adminUser = new AppUser();
                    adminUser.UserName = "Admin";

                    res = userManager.CreateAsync(adminUser, "P@ss123456").Result;

                    res = userManager.AddToRoleAsync(adminUser, "Admin").Result;
                }


                //theSportClubFaratechnoDBContext.SaveChanges();

            }




        }
    }
}
