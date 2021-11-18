using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SportClubFaratechno.ComponentsLibrary;
using Newtonsoft.Json;

namespace SportClubFaratechno.Models.Repository
{
    public class SportClubProcedures
    {
        private Response Response { get; set; } = new Response();
        #region تعاریف
        public Response CreateMasterType(string masterName)
        {


            //var sportClubRepositoryMasterType = TheServiceProvider.Instance.GetService<IGenericRepository<MasterType>>();
            var masterType = SportClubReposDI<MasterType>.OBJ;


            var foundName = masterType.Find(pp => pp.TypeName == masterName).FirstOrDefault();
            if (foundName != null)
            {
                Response.HasError = true;
                Response.Message = "نام مستر تکراری است.";
                return Response;
            }


            var lastRecord = masterType.GetAll().OrderByDescending(pp => pp.Id).FirstOrDefault();

            var maxOfValue = masterType.GetAll().Select(pp => long.Parse(pp.TypeId)).ToList().Max();

            masterType.Add(new MasterType { TypeName = masterName, TypeId = (++maxOfValue).ToString(), SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });

            //var ii = sportClubRepositoryMasterType.Find(pp => pp.Id == 1).OrderByDescending();
            return new Response();
        }



        public Response CreateDetailType(string masterName, string detailName, string description)
        {

            var masterTypeRepos = SportClubReposDI<MasterType>.OBJ;
            var detailTypeRepos = SportClubReposDI<DetailType>.OBJ;

            long? masterId = masterTypeRepos.Find(pp => pp.TypeName == masterName).Select(pp => pp.Id).FirstOrDefault();

            if (masterId == null)
            {
                Response.HasError = false;
                Response.Message = "مستر وجود ندارد";
                return Response;
            }

            var foundDetail = detailTypeRepos.Find(pp => pp.MasterId == masterId && pp.DetailName == detailName).FirstOrDefault();
            if (foundDetail != null)
            {
                Response.HasError = false;
                Response.Message = "نوع مورد نظر از قبل موجود است";
                return Response;
            }

            //detailType.

            long? maxOfDetailVal = detailTypeRepos.Find(pp => pp.MasterId == masterId).Select(pp => long.Parse(pp.DetailValue)).ToList().Max();
            detailTypeRepos.Add(new DetailType { MasterId = masterId, DetailValue = (++maxOfDetailVal).ToString(), DetailName = detailName, Description = description, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });

            return Response;
        }



        public Response GetListOfDetails(string masterName)
        {

            var masterTypeRepos = SportClubReposDI<MasterType>.OBJ;
            long? masterId = masterTypeRepos.Find(pp => pp.TypeName == masterName).Select(pp => pp.Id).FirstOrDefault();

            if (masterId == null)
            {
                Response.HasError = false;
                Response.Message = "مستر وجود ندارد";
                return Response;
            }

            var detailRepos = SportClubReposDI<DetailType>.OBJ;
            Response.Data = detailRepos.Find(pp => pp.MasterId == masterId).ToList();

            return Response;


        }

        public Response UpdateDetails(string masterName, string oldName, string newName)
        {

            var masterTypeRepos = SportClubReposDI<MasterType>.OBJ;
            long? masterId = masterTypeRepos.Find(pp => pp.TypeName == masterName).Select(pp => pp.Id).FirstOrDefault();

            if (masterId == null)
            {
                Response.HasError = false;
                Response.Message = "مستر وجود ندارد";
                return Response;
            }
            var detailRepos = SportClubReposDI<DetailType>.OBJ;
            var foundDetail = detailRepos.Find(pp => pp.MasterId == masterId && pp.DetailName == oldName).FirstOrDefault();
            if (foundDetail == null)
            {
                Response.HasError = false;
                Response.Message = "نام مورد نظر جستجو نشد";
                return Response;
            }
            foundDetail.DetailName = newName;
            detailRepos.Update(foundDetail);

            return Response;
        }

        public bool CheckMasterOfDetailId(string masterName, long detailId)
        {
            var master = SportClubReposDI<MasterType>.OBJ.Find(pp => pp.TypeName == masterName).FirstOrDefault();
            var res = SportClubReposDI<DetailType>.OBJ.Exists(pp => pp.MasterId == master.Id && pp.Id == detailId);
            return res;

        }



        #endregion

        #region کمد
        public Response CreateCabinet(CreateCabinetModel model)
        {


            var cabinetRepos = SportClubReposDI<Cabinet>.OBJ;

            var cabType = SportClubReposDI<DetailType>.OBJ.GetById(model.CabinetType);

            if (cabType == null)
            {
                Response.HasError = true;
                Response.Message = "نوع کمد مورد نظر یافت نشد.";
                return Response;
            }

            List<Cabinet> cabinets = new List<Cabinet>();
            foreach (var i in model.CabinetNames)
            {
                cabinets.Add(new Cabinet { CabinetName = i, CabinetType = model.CabinetType });
            }


            cabinetRepos.AddRange(cabinets);

            return Response;
        }

        public Response DeleteCabinet(long id)
        {

            Response Response = new Response("کمد مورد نظر حذف شد.");
            var cabinetRepos = SportClubReposDI<Cabinet>.OBJ;
            var foundCabinet = cabinetRepos.GetById(id);
            if (foundCabinet == null)
            {
                Response.HasError = true;
                Response.Message = "کمد مورد نظر یافت نشد.";
                return Response;
            }

            cabinetRepos.Remove(foundCabinet);
            return Response;

        }

        public Response DeleteCabinet(List<long> ids)
        {

            Response Response = new Response();
            var cabinetRepos = SportClubReposDI<Cabinet>.OBJ;
            List<Cabinet> deletedList = new List<Cabinet>();
            int deletedCount = 0;

            foreach (var i in ids)
            {
                var foundCabinet = cabinetRepos.GetById(i);
                if (foundCabinet == null)
                {

                    Response.Warning.Add($"کمد {i} یافت نشد.");
                }
                else
                {
                    deletedList.Add(foundCabinet);
                    cabinetRepos.Remove(foundCabinet);

                    deletedCount++;
                }
            }

            Response.Message = $"{deletedCount} کمد از {ids.Count} کمد حذف شد.";

            Response.Data = deletedList;



            return Response;

        }

        public Response AssignCabinetToUser(List<AssignCabinetToUserModel> model)
        {
            Response Response = new Response();
            var userCabinetRepos = SportClubReposDI<UserCabinet>.OBJ;
            var CabinetRepos = SportClubReposDI<Cabinet>.OBJ;
            List<UserCabinet> ucList = new List<UserCabinet>();
            int countSuccess = 0;
            foreach (var i in model)
            {
                var founduc = userCabinetRepos.Find(pp => pp.CabinetId == i.CabinetId).FirstOrDefault();

                if (founduc != null)
                {
                    var foundCabinet = CabinetRepos.GetById(founduc.CabinetId);
                    Response.Warning.Add($"کمد {foundCabinet.CabinetName} قبلا به یک کاربر اختصاص داده شده.");
                    continue;

                }

                ucList.Add(new UserCabinet { CabinetId = i.CabinetId, UserId = i.UserId, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });
                countSuccess++;
            }
            Response.Message = $"{countSuccess} کمد از {model.Count} به کاربران منتسب شد.";
            userCabinetRepos.AddRange(ucList);

            return Response;
        }

        public Response UnassignCabinetFromUser(List<AssignCabinetToUserModel> model)
        {


            var userCabinetRepos = SportClubReposDI<UserCabinet>.OBJ;
            var countSuccess = 0;
            List<UserCabinet> userCabinets = new List<UserCabinet>();
            foreach (var i in model)
            {
                var founduc = userCabinetRepos.Find(pp => pp.CabinetId == i.CabinetId && pp.UserId == i.UserId).FirstOrDefault();
                if (founduc == null)
                {
                    Response.Warning.Add($"کمد از قبل به کسی اختصاص داده نشده بود");
                    continue;
                }
                userCabinets.Add(new UserCabinet { CabinetId = i.CabinetId, UserId = i.UserId });

                countSuccess++;
            }
            Response.Message = $"{countSuccess} کمد از {model.Count} حذف شد.";
            userCabinetRepos.RemoveRange(userCabinets);

            return Response;
        }

        public Response GetListOfCabinets()
        {
            var cabinetRepos = SportClubReposDI<Cabinet>.OBJ;
            Response.Data = cabinetRepos.GetAll();
            return Response;
        }







        #endregion

        #region بوفه

        public Response AddBuffetItem(AddBuffetItemModel model)
        {

            var buffetDetailRepos = SportClubReposDI<BuffetDetail>.OBJ;
            var detailRepos = SportClubReposDI<DetailType>.OBJ;

            if (!CheckMasterOfDetailId("بوفه", model.BuffetId.Value))
            {
                Response.HasError = true;
                Response.Message = $"بوفه مورد نظر موجود نیست.";
                return Response;
            }

            List<BuffetDetail> buffetDetails = new List<BuffetDetail>();
            foreach (var i in model.items)
            {

                if (!CheckMasterOfDetailId("اقلام بوفه", i.BuffetItem.Value))
                {
                    var tmpdetail = detailRepos.Find(pp => pp.Id == i.BuffetItem).FirstOrDefault();
                    Response.Warning.Add($"آی دی {i.BuffetItem} مربوط به {tmpdetail.DetailName} میباشد و جزء اقلام بوفه محسوب نمیشود");
                    continue;
                }

                if (buffetDetailRepos.Exists(pp => pp.BuffetItem == i.BuffetItem))
                {
                    var detailTmp = detailRepos.GetById(i.BuffetItem);
                    Response.Warning.Add($"{detailTmp.DetailName} از قبل موجود است لطفا به تغییر موجودی یا تغییر قیمت اقدام کنید.");
                    continue;
                }
                buffetDetails.Add(new BuffetDetail { BuffetId = model.BuffetId, BuffetItem = i.BuffetItem, Price = i.Price, Quantity = i.Quantity, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });
            }

            //buffetDetailRepos.Add(new BuffetDetail { BuffetId = model.BuffetId, BuffetItem = model.BuffetItem, Price = model.Price, Quantity = model.Quantity, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });
            buffetDetailRepos.AddRange(buffetDetails);
            Response.Message = $"{buffetDetails.Count} قلم از {model.items.Count} جنس به بوفه اضافه شد.";
            return Response;
        }


        internal Response UpdateBuffetItem(UpdateBuffetItemModel model)
        {
            //var log = new { changes = new Dictionary<string , BuffetDetail>() };
            var theLog = new LogChanges<BuffetDetail>();
            var buffetDetailRepos = SportClubReposDI<BuffetDetail>.OBJ;
            var theBuffetDetail = buffetDetailRepos.GetById(model.Id);

            //log.changes.Add("beforeChange",theBuffetDetail.Clone());
            theLog.BeforeChage = theBuffetDetail.Clone();
            theBuffetDetail.Price = model.Price ?? theBuffetDetail.Price;
            theBuffetDetail.Quantity = model.Quantity ?? theBuffetDetail.Quantity;
            buffetDetailRepos.SaveChanges();
            //log.changes.Add("afterchange", theBuffetDetail.Clone());
            theLog.AfterChange = theBuffetDetail;
            Response.Data = theLog;
            return Response;
        }

        public Response RemoveBuffetItem(long id)
        {
            var buffetDetailRepos = SportClubReposDI<BuffetDetail>.OBJ;
            var found = buffetDetailRepos.GetById(id);


            if (found == null)
            {
                Response.HasError = true;
                Response.Message = "کالای مورد نظر یافت نشد.";
                return Response;
            }

            LogChanges<BuffetDetail> logChanges = new LogChanges<BuffetDetail>();

            logChanges.Detelted = found;
            Response.Data = logChanges;
            buffetDetailRepos.Remove(found);
            return Response;

        }

        #endregion

        #region سالن
        internal Response AssignSportToSalon(AssignSportToSalonModel model)
        {
            var detailTypeRepos = SportClubReposDI<DetailType>.OBJ;
            var masterRepos = SportClubReposDI<MasterType>.OBJ;
            var salonMasterId = masterRepos.Find(pp => pp.TypeName == "سالن").FirstOrDefault().Id;
            var sportMasterId = masterRepos.Find(pp => pp.TypeName == "رشته ورزشی").FirstOrDefault().Id;
            var foundSalon = detailTypeRepos.Exists(pp => pp.Id == model.SalonTypeId && pp.MasterId == salonMasterId);
            var foundSport = detailTypeRepos.Exists(pp => pp.Id == model.SalonTypeId && pp.MasterId == sportMasterId);
            if (!foundSalon)
            {
                Response.HasError = true;
                Response.Message = "سالن مورد نظر یافت نشد.";
                return Response;
            }
            if (foundSport)
            {
                Response.HasError = true;
                Response.Message = "رشته ورزشی  مورد نظر یافت نشد.";
                return Response;
            }



            var salonSportRepos = SportClubReposDI<SalonSport>.OBJ;

            var foundSalonSport = salonSportRepos.Exists(pp => pp.SalonTypeId == model.SalonTypeId && pp.SportTypeId == model.SportTypeId);
            if (foundSalonSport)
            {
                Response.HasError = true;
                Response.Message = "رشته ورزشی قبلا به سالن انتساب داده شده است.";
                return Response;
            }

            var res = salonSportRepos.Add(new SalonSport { SalonCabinetPrioraty = false, SalonTypeId = model.SalonTypeId, SportTypeId = model.SportTypeId, Desctiption = model.Desctiption, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });
            Response.LogChanges = salonSportRepos.LogChanges;
            Response.Data = res;
            return Response;
        }

        public Response GetListOfSportSalon()
        {
            var salonSportRepos = SportClubReposDI<SalonSport>.OBJ;
            Response.Data = salonSportRepos.GetAll();
            return Response;
        }

        public Response UpdateSalonSport(UpdateSalonSportModel model)
        {

            var salonSportRepos = SportClubReposDI<SalonSport>.OBJ;
            var salonSportExists = salonSportRepos.Exists(pp => pp.SalonTypeId == model.SalonTypeId && pp.SportTypeId == model.SportTypeId);

            if (salonSportExists)
            {
                Response.HasError = true;
                Response.Message = "رشته سالن مورد نظر از قبل موجود است";
                return Response;
            }

            var found = salonSportRepos.GetById(model.Id);
            var cloneFound = found.Clone();
            found.SalonTypeId = model.SalonTypeId ?? found.SalonTypeId;
            found.SportTypeId = model.SportTypeId ?? found.SportTypeId;
            found.Desctiption = model.Desctiption ?? found.Desctiption;
            found.SalonCabinetPrioraty = model.SalonCabinetPrioraty ?? found.SalonCabinetPrioraty;

            salonSportRepos.SaveChanges();

            LogChanges<SalonSport> logChanges = new LogChanges<SalonSport>();
            logChanges.ActionName = "Update";
            logChanges.BeforeChage = cloneFound;
            logChanges.AfterChange = found;
            Response.LogChanges = logChanges;

            return Response;
        }


        public Response DeleteSalonSport(long id)
        {
            var salonSportRepos = SportClubReposDI<SalonSport>.OBJ;

            var found = salonSportRepos.GetById(id);

            salonSportRepos.Remove(found);

            Response.LogChanges = salonSportRepos.LogChanges;

            return Response;

        }

        internal Response AddSalonEqueepmet(AddSalonEqueepmetModel model)
        {
            if (model.IsFreeToUse == false)
            {
                if (model.Price == 0 || model.Price == null)
                {
                    Response.HasError = true;
                    Response.Message = "لطفا قیمت استفاده از دستگاه را وارد کنید.";
                    return Response;
                }
            }

            var salonequeepmentRepos = SportClubReposDI<SalonEquipment>.OBJ;
            salonequeepmentRepos.Add(new SalonEquipment { SalonId = model.SalonId, Quantity = model.Quantity, IsFreeToUse = model.IsFreeToUse, Equipment = model.Equipment, Price = model.Price, Description = model.Description });
            Response.LogChanges = salonequeepmentRepos.LogChanges;
            return Response;
        }

        internal Response ListOfSalonEqueepments()
        {

            var salonequeepmentRepos = SportClubReposDI<SalonEquipment>.OBJ;
            var res = salonequeepmentRepos.GetAll();
            Response.Data = res;
            return Response;
        }


        internal Response UpdateEqueepment(UpdateEqueepmentModel model)
        {

            if (model.IsFreeToUse == false)
            {
                if (model.Price == 0 || model.Price == null)
                {
                    Response.HasError = true;
                    Response.Message = "لطفا قیمت استفاده از دستگاه را وارد کنید.";
                    return Response;
                }
            }

            var salonequeepmentRepos = SportClubReposDI<SalonEquipment>.OBJ;
            var found = salonequeepmentRepos.GetById(model.Id);

            salonequeepmentRepos.LogChanges.ActionName = "update";
            salonequeepmentRepos.LogChanges.BeforeChage = found;
            found.Equipment = model.Equipment ?? found.Equipment;
            found.Description = model.Description ?? found.Description;
            found.IsFreeToUse = model.IsFreeToUse ?? found.IsFreeToUse;
            found.Quantity = model.Quantity ?? found.Quantity;
            found.SalonId = model.SalonId ?? found.SalonId;
            found.Price = model.Price ?? found.Price;
            salonequeepmentRepos.LogChanges.AfterChange = found;
            Response.LogChanges = salonequeepmentRepos.LogChanges;
            return Response;
        }



        public Response DeleteEqueepment(long id)
        {
            var salonequeepmentRepos = SportClubReposDI<SalonEquipment>.OBJ;
            salonequeepmentRepos.RemoveById(id);
            Response.LogChanges = salonequeepmentRepos.LogChanges;
            return Response;
        }




        #endregion

        #region جلسات

        public Response CreateSession(CreateSalonSportSessionModel model)
        {


            var sessionRepos = SportClubReposDI<Session>.OBJ;

            var dbContext = TheServiceProvider.Instance.GetService<SportClubFaratechnoDBContext>();

            var res = (from a in dbContext.MasterType
                       join b in dbContext.DetailType on a.Id equals b.MasterId
                       where a.TypeName == "وضعیت دوره" && b.DetailName == "در انتظار برگزاری"
                       select b).FirstOrDefault();

            sessionRepos.Add(new Session { SalonSportId = model.SalonSportId, StartDate = PersianDate.ConvertToGregorian(model.StartDateShamsi), EndDate = PersianDate.ConvertToGregorian(model.EndDateShamsi), Description = model.Description, EndDateShamsi = model.EndDateShamsi, StartDateShamsi = model.StartDateShamsi, StartTime = model.StartTime, EndTime = model.EndTime, Sex = model.Sex, NumberOfPeople = model.NumberOfPeople, State = res.Id, NumberOfSessions = model.NumberOfSessions, AtAprice = model.AtAprice, TotalPrice = model.TotalPrice, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });

            Response.LogChanges = sessionRepos.LogChanges;

            return Response;
        }

        public Response EditSession(EditSessionModel model)
        {

            var sessionRepos = SportClubReposDI<Session>.OBJ;
            var found = sessionRepos.GetById(model.Id);

            LogChanges<Session> logChanges = new LogChanges<Session>();
            logChanges.ActionName = "update";
            logChanges.BeforeChage = found.Clone();

            found.AtAprice = model.AtAprice ?? found.AtAprice;
            found.Description = model.Description ?? found.Description;
            found.EndDate = model.EndDate ?? found.EndDate;
            found.EndDateShamsi = model.EndDateShamsi ?? found.EndDateShamsi;
            found.EndTime = model.EndTime ?? found.EndTime;
            found.NumberOfPeople = model.NumberOfPeople ?? found.NumberOfPeople;
            found.NumberOfSessions = model.NumberOfSessions ?? found.NumberOfSessions;
            found.SalonSportId = model.SalonSportId ?? found.SalonSportId;
            found.Sex = model.Sex ?? found.Sex;
            found.StartDate = model.StartDate ?? found.StartDate;
            found.StartDateShamsi = model.StartDateShamsi ?? found.StartDateShamsi;
            found.StartTime = model.StartTime ?? found.StartTime;
            found.State = model.State ?? found.State;
            logChanges.AfterChange = found.Clone();

            Response.LogChanges = logChanges;

            sessionRepos.SaveChanges();

            return Response;

        }


        internal Response ListOfSessions()
        {
            var sessionRepos = SportClubReposDI<Session>.OBJ;
            Response.Data = sessionRepos.GetAll();
            return Response;
        }

        internal Response DeleteSession(long id)
        {
            var sessionRepos = SportClubReposDI<Session>.OBJ;
            sessionRepos.RemoveById(id);
            Response.LogChanges = sessionRepos.LogChanges;
            return Response;
        }

        public Response CreateSessionDetail(CreateSessionDetailModel model)
        {

            List<SessionDetail> lst = new List<SessionDetail>();
            foreach (var i in model.sessionDetailItems)
            {
                lst.Add(new SessionDetail { SessionId = model.SessionId, SessionDateShamsi = i.SessionDateShamsi, SessionDate = PersianDate.ConvertToGregorian(i.SessionDateShamsi), State = i.State, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash, Description = i.Description });

            }

            var sessionDetailRepos = SportClubReposDI<SessionDetail>.OBJ;
            sessionDetailRepos.AddRange(lst);
            Response.LogChanges = sessionDetailRepos.LogChanges;
            return Response;
        }

        public Response EditSessionDetail(EditSessionDetailModel model)
        {
            var sessionDetailRepos = SportClubReposDI<SessionDetail>.OBJ;



            var found = sessionDetailRepos.GetById(model.Id);

            LogChanges<SessionDetail> logChanges = new LogChanges<SessionDetail>();
            logChanges.BeforeChage = found;
            found.SessionId = model.SessionId;
            found.SessionDateShamsi = model.SessionDateShamsi ?? found.SessionDateShamsi;
            found.SessionDate = PersianDate.ConvertToGregorian(found.SessionDateShamsi);
            found.State = model.State ?? found.State;
            found.Description = model.Description ?? found.Description;
            logChanges.AfterChange = found;
            Response.LogChanges = logChanges;

            sessionDetailRepos.SaveChanges();
            return Response;
        }


        public Response DeleteSesssionDetail(long id)
        {
            var sessionDetailRepos = SportClubReposDI<SessionDetail>.OBJ;
            sessionDetailRepos.RemoveById(id);

            Response.LogChanges = sessionDetailRepos.LogChanges;

            return Response;
        }


        public Response RegisterUserSession(RegisterUserSessionModel model)
        {

            var sessioUserRepos = SportClubReposDI<SessionUser>.OBJ;

            var dbContext = TheServiceProvider.Instance.GetService<SportClubFaratechnoDBContext>();

            List<SessionUser> sessionUsers = new List<SessionUser>();

            foreach (var i in model.userInfoLst)
            {
                var UserExists = sessioUserRepos.Exists(pp => pp.UserId == i.UserId && pp.SessionId == model.SessionId);
                if (UserExists)
                {
                    var foundUser = dbContext.Users.Find(i.UserId);
                    Response.Warning.Add($"{foundUser.FirstName} {foundUser.LastName} از قبل در این دوره ثبت نام کرده است.");
                    continue;
                }

                sessionUsers.Add(new SessionUser { SessionId = model.SessionId, UserId = i.UserId, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });
            }

            sessioUserRepos.AddRange(sessionUsers);
            Response.LogChanges = sessioUserRepos.LogChanges;
            Response.Message = $"{sessionUsers.Count} از {model.userInfoLst.Count} ثبت نام شدند ";

            return Response;
        }

        public Response UpdateUserSession(UpdateUserSessionModel model)
        {
            var sessioUserRepos = SportClubReposDI<SessionUser>.OBJ;

            var foundUser = sessioUserRepos.GetById(model.Id);
            LogChanges<SessionUser> logChanges = new LogChanges<SessionUser>();
            logChanges.BeforeChage = foundUser;
            foundUser.SessionId = model.SessionId ?? foundUser.SessionId;
            foundUser.UserId = model.UserId ?? foundUser.UserId;
            logChanges.AfterChange = foundUser;

            Response.LogChanges = logChanges;
            return Response;
        }

        public Response DeleteUserSession(long id)
        {
            var sessioUserRepos = SportClubReposDI<SessionUser>.OBJ;
            sessioUserRepos.RemoveById(id);
            Response.LogChanges = sessioUserRepos.LogChanges;
            return Response;
        }


        public Response EnterSessionUserTraffic(EnterSessionUserTrafficModel model)
        {

            var sessionUserTrafficRepos = SportClubReposDI<SessionUserTraffic>.OBJ;
            sessionUserTrafficRepos.Add(new SessionUserTraffic { SessionUserId = model.SessionUserId, EntranceDatetimeShamsi = PersianDate.NowGetWithSlash, EntranceDatetime = DateTime.Now, Description = model.Description, SubmissionDate = DateTime.Now, SubmissionDateShamsi = PersianDate.NowGetWithSlash });
            Response.LogChanges = sessionUserTrafficRepos.LogChanges;
            return Response;
        }

        public Response ExitSessionUserTraffic(ExitSessionUserTrafficModel model)
        {

            var sessionUserTrafficRepos = SportClubReposDI<SessionUserTraffic>.OBJ;

            var found = sessionUserTrafficRepos.Find(pp => pp.SessionUserId == model.SessionUserId && pp.ExitDatetime == null).FirstOrDefault();

            var foundClone = found.Clone();

            found.ExitDatetime = DateTime.Now;
            found.ExitDatetimeShamsi = PersianDate.NowGetWithSlash;

            sessionUserTrafficRepos.Update(found);
            sessionUserTrafficRepos.LogChanges.BeforeChage = foundClone;

            return Response;
        }

        public Response DeleteSessionUserTraffic(long id)
        {
            var sessionUserTrafficRepos = SportClubReposDI<SessionUserTraffic>.OBJ;
            sessionUserTrafficRepos.RemoveById(id);
            Response.LogChanges = sessionUserTrafficRepos.LogChanges;
            return Response;
        }

        #endregion

        #region تراکنش ها

        public Response TransactionInsert(TransactionInsertModel model)
        {

            var transactionRepos = SportClubReposDI<Transaction>.OBJ;

            var res = transactionRepos.Add(new Transaction {Description = model.Description , Price = model.Price , SubmissionDate = DateTime.Now , SubmissionDateShamsi = PersianDate.NowGetWithSlash, TrnSource=model.TrnSource , TrnType= model.TrnType , UserId = model.UserId });

            Response.LogChanges = transactionRepos.LogChanges;
            Response.Data = res;
            return Response;
            
        }



        #endregion








    }
}
